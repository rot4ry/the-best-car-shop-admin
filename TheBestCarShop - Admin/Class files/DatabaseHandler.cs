using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Dapper;
using TheBestCarShop.Class_files;

namespace TheBestCarShop
{
    public class DatabaseHandler
    {
        public string connectionString = @"
                    Data Source=DESKTOP-GSQML5J\MYSERVER;
                    Initial Catalog=TheShop;
                    Integrated Security=True;
                    Connect Timeout=30;
                    Encrypt=False;
                    TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;
                    MultiSubnetFailover=False";
        
        //PRODUCT RELATED METHODS
        public List<Product> GetAvailableProductsList()
        {
            List<Product> availableProductsList;

            string query = "SELECT * FROM Products WHERE IsAvailable=1";

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                availableProductsList = connection.Query<Product>(query).ToList<Product>();
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);                return (List<Product>) null;
            }
            return availableProductsList;
        }
        public Product GetProduct(int id)
        {
            string query = "SELECT * FROM Products WHERE ProductID = @id";
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                Product product = connection.QuerySingle<Product>(query, new { id = id });
                connection.Close();

                return product;
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
                return (Product)null;
            }
        }
        public int UpdateProductQuantityBasedOnKart(int productID, int quantity)
        {
            //to use in ConfirmOrder ONLY
            string update = "UPDATE Products " +
                            "SET Quantity = Quantity - @quantity, IsAvailable = @isavailable " +
                            "WHERE ProductID = @productID ";
            
            int affected = 0;
            Product product = this.GetProduct(productID);
            
            if (product.Quantity < quantity)
            {
                return 1234567;
            }
            else if(product.Quantity == quantity)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(this.connectionString);
                    affected = connection.Execute(update, new
                    {
                        quantity = quantity,
                        isavailable = false,
                        productID = productID
                    });
                    connection.Close();
                }
                catch (Exception DatabaseHandlerException)
                {
                    Console.WriteLine(DatabaseHandlerException.Message);
                }
            }
            else if (product.Quantity > quantity)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(this.connectionString);
                    affected = connection.Execute(update, new
                    {
                        quantity = quantity,
                        isavailable = true,
                        productID = productID
                    });
                    connection.Close();
                }
                catch (Exception DatabaseHandlerException)
                {
                    Console.WriteLine(DatabaseHandlerException.Message);
                }
            }
            return affected;
        }
        public int GetAvailableQuantity(int productID)
        {
            string query =  "SELECT Quantity " +
                            "FROM Products " +
                            "WHERE ProductID = @productID ";
            int quantity = 0;
            
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                quantity = connection.QuerySingle<int>(query, new { productID = productID });
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return quantity;
        }


        //ORDER RELATED METHODS
        public int AddUnplacedOrder(int ClientID)
        {
            string insert = 
                "INSERT INTO Orders([CustomerID],[ReceivedDate],[SentDate],[DeliveredDate],[IsPlaced]) " +
                "VALUES (@customerId, @receivedDate, @sentDate, @deliveredDate, @isPlaced)";
            int affected = 0;
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(insert,
                    new {   customerId = ClientID, 
                            receivedDate = DateTime.Now,
                            sentDate = DateTime.Now,    
                            deliveredDate = DateTime.Now,
                            isPlaced = false 
                    });
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return affected;
        }
        public int RemoveUnplacedOrder(int ClientID)
        {
            string delete = "DELETE FROM Orders " +
                            "WHERE CustomerID = @clientID " +
                            "AND IsPlaced = 'false'";
            
            int affected = 0;
            
            //deletes all OrderDetails connected to an unplaced order
            this.ClearKart(this.GetShoppingKartID(ClientID));
            
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(delete, new { clientID = ClientID });
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return affected;
        }
        public int RemoveAllUnplacedOrders()
        {
            //this method mostly will do nothing
            //as unplaced Orders and their OrderDetails 
            //are removed while user is logging out
            //however
            //in case of any bugs/errors, this method kicks in
            //while launching the app
            string select = "SELECT OrderID " +
                            "FROM Orders " +
                            "WHERE IsPlaced = 'false' ";

            string delete = "DELETE FROM Orders " +
                            "DELETE FROM OrderDetails " +
                            "WHERE OrderID = @unplacedOrderID ";
            
            int deleted = 0;
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                
                List<int> unplacedIDs = connection.Query<int>(select).ToList<int>();
                if (unplacedIDs != null)
                {
                    foreach (int item in unplacedIDs)
                    {
                        deleted += connection.Execute(delete, new { unplacedOrderID = item });
                    }
                }
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return deleted;
        }
        public int GetShoppingKartID(int ClientID)
        {
            string query = 
                "SELECT TOP 1 [OrderID] " +
                "FROM Orders " +
                "WHERE [CustomerID] = @clientID " +
                "AND [IsPlaced] = 'false' ";
            int ID = 0;
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                ID = connection.QuerySingle<int>(query, new { clientID = ClientID });
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return ID;
        }
        public int ConfirmOrder(int ClientID, int shoppingKartID)
        {
            string update =
                "UPDATE Orders " +
                "SET [IsPlaced] = 'true' " +
                "WHERE [CustomerID] = @clientID " +
                "AND [OrderID] = @shoppingKartID ";
            int affected = 0;

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(update, new { clientID = ClientID, shoppingKartID = shoppingKartID });
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            
            //when an order is confirmed,
            //a new shopping kart is created
            this.AddUnplacedOrder(ClientID);
            return affected;
        }

        
        //ORDER DETAILS RELATED METHODS
        public int AddToKartIfNotExists(int shoppingKartID, int productID)
        {
            string insert =
                "INSERT INTO OrderDetails([OrderID],[ProductID],[Price],[Quantity]) " +
                "VALUES (@orderID, @productID, @price, @quantity) ";

            string select = "SELECT COUNT(*) FROM OrderDetails " +
                            "WHERE OrderID = @kartID " +
                            "AND ProductID = @productID";
            //prevents duplicates
            Product requested = this.GetProduct(productID);
            int affected = 0;

            if (requested != null)
            {
                try
                {
                    SqlConnection connection = new SqlConnection(this.connectionString);

                    int existing = connection.QuerySingle<int>(select, 
                        new { 
                            kartID = shoppingKartID,
                            productID = productID 
                        });

                    if (existing == 0)
                    {

                        affected = connection.Execute(insert, new
                        {
                            orderID = shoppingKartID,
                            productID = requested.ProductID,
                            price = requested.Price,
                            quantity = 1
                        });
                    }
                    connection.Close();
                }
                catch (Exception DatabaseHandlerException)
                {
                    Console.WriteLine(DatabaseHandlerException.Message);
                }
            }
            else
            {
                form_SystemMessage failure = new form_SystemMessage("Sorry.", "We couldn't find this item.");
            }
            return affected;
        }
        public int RemoveFromKart(int shoppingKartID, int productID)
        {
            string delete =
                "DELETE FROM OrderDetails " +
                "WHERE OrderID = @shoppingKartID " +
                "AND ProductID = @productID ";
            int affected = 0;

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(delete, new
                {
                    shoppingKartID = shoppingKartID,
                    productID = productID
                });
                connection.Close();
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return affected;
        }
        public List<OrderDetail> GetKartList(int shoppingKartID)
        {
            string query =  "SELECT * " +
                            "FROM OrderDetails " +
                            "WHERE OrderID = @kartID";
            
            List<OrderDetail> shoppingKartList = new List<OrderDetail>();
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);

                IEnumerable<OrderDetail> queryResult = 
                    connection.Query<OrderDetail>(query, new
                                    {
                                        kartID = shoppingKartID
                                    });
                shoppingKartList = queryResult.ToList<OrderDetail>();
                
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return shoppingKartList;
        }
        public int UpdateQuantityInKart(int shoppingKartID, int productID, int newQuantity)
        {
            string update = "UPDATE OrderDetails " +
                            "SET Quantity = @newQuantity " +
                            "WHERE OrderID = @shoppingKartID " +
                            "AND ProductID = @productID ";
            
            int affected = 0;
            
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(update,
                                    new { 
                                        newQuantity = newQuantity,
                                        shoppingKartID = shoppingKartID,
                                        productID = productID
                                    });
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return affected;
        }
        public int ClearKart(int shoppingKartID)
        {
            string delete = "DELETE FROM OrderDetails " +
                            "WHERE OrderID = @kartID ";
            int affected = 0;

            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                affected = connection.Execute(delete,
                    new
                    {
                        kartID = shoppingKartID
                    });
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }

            return affected;
        }
        

        //USER RELATED METHODS
        public int AddUser(Client client, bool isAdmin = false)
        {

            SqlConnection connection = new SqlConnection(this.connectionString);
            int affected = connection.Execute(
                "INSERT INTO Clients([FirstName], " +
                "[SecondName], [CompanyName], [Email], [PhoneNumber], [Country], " +
                "[City], [Street], [Postcode], [BuildingNumber], " +
                "[Username], [Password],[IsAdmin]) " +

                "VALUES(@firstName, @secondName, @companyName, @email, @phone, " +
                "@country, @city, @street, @postcode, @buildingNumber, @username, " +
                "@password, @isAdmin)",
                new
                {
                    firstName = client.FirstName,
                    secondName = client.SecondName,
                    companyName = client.CompanyName,
                    email = client.Email,
                    phone = client.PhoneNumber,
                    country = client.Country,
                    city = client.City,
                    street = client.Street,
                    postcode = client.Postcode,
                    buildingNumber = client.BuildingNumber,
                    username = client.Username,
                    password = client.Password,
                    isAdmin = isAdmin
                });

            connection.Close();
            return affected;
        }
        public bool CheckLoginData(string username, string password)
        {
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                
                var queryResult = 
                    (connection.Query<int>(
                    "SELECT *  " +
                    "FROM Clients " +
                    "WHERE [Username] = @username " +
                    "AND " +
                    "[Password] = @password "
                    , new { username = username, password = password })).Count();
                
                connection.Close();
                return queryResult == 1 ? true : false;
            }
            catch (Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
                Console.WriteLine("DatabaseHandlerException CheckLoginData");
                return false;
            }
        }
        public Client GetClientDetails(string username)
        {
            SqlConnection connection = new SqlConnection(this.connectionString);
            
            string query = @"SELECT 
                            [ClientID] 
                            ,[FirstName] 
                            ,[SecondName] 
                            ,[CompanyName] 
                            ,[Email] 
                            ,[PhoneNumber] 
                            ,[Country]
                            ,[City] 
                            ,[Street] 
                            ,[Postcode] 
                            ,[BuildingNumber]
                            ,[Username] 
                            ,[Password]
                            ,[IsAdmin] 
                            FROM Clients
                            WHERE Username = @username";
            try
            {
                Client client = connection.QuerySingle<Client>
                    (query, new { username = username });
                connection.Close();
                return client;
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
                return (Client)null;
            }
        }
        public int UpdateClientField(string columnName, string value, string username)
        {
            int affected = 0;
            SqlConnection connection = new SqlConnection(this.connectionString);
            string update = "UPDATE Clients " +
                            $"SET {columnName} = @value " +
                            "WHERE Username = @username ";
            try
            {
                affected = connection.Execute(update, new { value = value, username = username });
            }
            catch (Exception DatabaseHandlerException) { Console.WriteLine(DatabaseHandlerException.Message); }

            if (affected == 1)
            {
                form_SystemMessage success = new form_SystemMessage("Success!", $"Data has been updated!");
            }
            else
            {
                form_SystemMessage failure = new form_SystemMessage("Failure!", "Something went wrong.");
            }
            
            connection.Close();
            return affected;
        }
        public int DeleteUser(string username)
        {
            int affected = 0;

            SqlConnection connection = new SqlConnection(this.connectionString);
            string delete = "DELETE Clients WHERE Username = @username";

            try
            {
                affected = connection.Execute(delete, new { username = username });
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            connection.Close();
            return affected;
        }
        
        //OTHER
        public List<ShoppingHistoryPosition> GetCustomerHistory(int ClientID)
        {
            string select = 
                "SELECT ReceivedDate, SentDate, DeliveredDate, " +
                "Products.Name as Name, OrderDetails.Price as Price, OrderDetails.Quantity as Quantity " +
                "FROM Orders " +
                    "INNER JOIN " +
                    "OrderDetails " +
                        "ON Orders.OrderID = OrderDetails.OrderID " +
                    "INNER JOIN " +
                    "Products " +
                    "ON OrderDetails.ProductID = Products.ProductID " +
                "WHERE IsPlaced = 'true' AND CustomerID = @clientID ";
            List<ShoppingHistoryPosition> shoppingHistory = new List<ShoppingHistoryPosition>();
            
            try
            {
                SqlConnection connection = new SqlConnection(this.connectionString);
                shoppingHistory = connection
                    .Query<ShoppingHistoryPosition>(select, new
                                                    { 
                                                        clientID = ClientID 
                                                    })
                    .ToList<ShoppingHistoryPosition>();
                connection.Close();
            }
            catch(Exception DatabaseHandlerException)
            {
                Console.WriteLine(DatabaseHandlerException.Message);
            }
            return shoppingHistory;
        }
    }
}

