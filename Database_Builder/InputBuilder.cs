using System;
using System.Data.SqlTypes;
using System.Text;

namespace Database_Builder
{
    public class InputBuilder
    {
        //Generates random products from the word arrays

        private static string[][] BrandsNModels = new string[][]
        {
            new string[]{"Abarth"       , "500", "595", "124 Spider" },
            new string[]{"Alpine"       , "A110", "A310", "A610"},
            new string[]{"Autozam"      , "AZ1" },
            new string[]{"Caterham"     , "Seven SuperSprint", "Seven 310", "Seven 620S", "Seven Superlight Twenty" },
            new string[]{"Datsun"       , "100A", "240Z", "260Z", "280Z" },
            new string[]{"Honda"        , "S2000", "Civic EK9", "Prelude III", "Prelude V" },
            new string[]{"Koenigsegg"   , "Agera RS", "Regera", "Gemera" },
            new string[]{"Lexus"        , "IS200", "IS300", "LC500", "LFA" },
            new string[]{"Lotus"        , "Omega", "Elise", "Elise", "Espirit" },
            new string[]{"Mazda"        , "3", "5", "6", "MX-3", "MX-5", "MX-6", "Cosmo", "Cosmo Sport", "RX7", "RX8" },
            new string[]{"Mitsubishi"   , "Galant", "Lancer", "Lancer Evolution", "Eclipse", "3000GT", "FTO", "L300" },
            new string[]{"Morgan"       , "3Wheeler", "PlusFour", "PlusSix" },
            new string[]{"Nissan"       , "180sx", "200sx", "240sx", "300ZX", "Skyline", "GT-R R32", "GT-R R33", "GT-R R34" },
            new string[]{"Porsche"      , "911", "944", "924", "928" },
            new string[]{"Saab"         , "900T", "9-3", "9-5", "SK60" },
            new string[]{"Scion"        , "xd", "FRS" },
            new string[]{"Subaru"       , "BRZ", "Impreza", "Legacy", "Forester", "Outback", "Libero" },
            new string[]{"Toyota"       , "Celica", "AE86", "MR2", "Supra III", "Supra IV", "Supra V"},
            new string[]{"Volvo"        , "240DL", "940" },
        };

        private static string[] ProductCategories = new string[] {
            "Steering Wheels", "Shifter Knobs", "Alloy Rims", "Steel Rims",
            "Cast Rims", "Forged Rims", "Front Windshield", "Electrical Components",
            "Headlights", "Rear Lights", "Blinkers", "Blinker Fluid",
            "Exhaust Bearings", "ECUs", "Turbochargers", "Superchargers",
            "Timing Belts", "Valves", "Zimmerings", "Clutch Kits", "Pistons",
            "Camshafts", "Crankshafts", "Mufflers", "Engine Oil",
            "Gearbox Oil", "Speakers", "Oil Filters", "Air Filters",
            "Lug Nuts", "Others", "Open Differentials", "LSDs", "Water Pumps",
            "Starters", "Radiators", "Manifolds", "Ignition Coils", "Spark Plugs",
            "Gaskets"
        };

        private static string[] ProductName = new string[]
        {
            "Steering Wheel", "Shifter Knob", "Alloy Rim", "Steel Rim",
            "Cast Rim", "Forged Rim", "Front Windshield", "Electrical Component",
            "Headlight", "Rear Light", "Blinker", "Blinker Fluid",
            "Exhaust Bearing", "ECU", "Turbocharger", "Supercharger",
            "Timing Belt", "Valve", "Zimmering", "Clutch Kit", "Piston",
            "Camshaft", "Crankshaft", "Muffler", "Engine Oil",
            "Gearbox Oil", "Speaker", "Oil Filter", "Air Filter",
            "Lug Nut", "Other", "Open Differential", "LSD", "Water Pump",
            "Starter", "Radiator", "Manifold", "Ignition Coil", "Spark Plug",
            "Gasket"
        };

        private static string[] ProducerNames = new string[]
        {
            "Enkei", "Brembo", "Bilstein", "Bosch", "JapanParts", "Textar",
            "Sparco", "TheBoringCompany", "Doofenschmirtz INC.", "MakroHard",
            "BIM", "Blast", "4Bangers", "DieselSucks INC", "E-Corp",
            "WankelGang", "MyNameIsRandom", "Wilwood"
        };

        private static string[] RandomCoolSoundingWords = new string[]
        {
            "Super", "Turbo", "Mega", "Proper chapZ", "Inadequately loud",
            "Mad ladZ", "Top blokeZ","RenegadeZ" , "Supersonic",
            "Abundand", "Jam-Packed", "Mucho","Velocitious", "Vrooomy",
            "Speedy boiZ", "Jeremy Clarkson recommended"
        };

        private static string[] Quality = new string[]
        {
            "of reasonable quality", "of medium quality", "of proper quality",
            "of mediocre quality", "of platinum quality", "of unbreakable", " "
        };

        public static Product BuildProduct()
        {
            Random rnd = new Random();
            //INCREASING ENTROPY 
            int brandID = rnd.Next(BrandsNModels.GetLength(0));
            int modelID = rnd.Next(1, BrandsNModels[brandID].GetLength(0));

            string carBrand = @BrandsNModels[brandID][0];
            string carModel = @BrandsNModels[brandID][modelID];

            int fYear = (int)(rnd.Next(1950, 2020));
            int lYear = (int)(fYear + rnd.Next(3, 15));

            decimal price = (decimal)(Math.Pow(10, rnd.Next(2, 5))
                                                * rnd.NextDouble());
            price = Math.Round(price, 2);
            
            //GENERATING CHAOS
            int wordID = rnd.Next(RandomCoolSoundingWords.GetLength(0));
            int producerID = rnd.Next(ProducerNames.GetLength(0));
            int productSlashCategoryID = rnd.Next(ProductName.GetLength(0));
            int qualityID = rnd.Next(Quality.GetLength(0));

            string partName =
                new StringBuilder().Append(@RandomCoolSoundingWords[wordID]).Append(" ")
                    .Append(@ProducerNames[producerID]).Append(" ")
                    .Append(@ProductName[productSlashCategoryID]).Append(" ")
                    .Append(@Quality[qualityID])
                    .ToString();

            string partCategory = @ProductCategories[productSlashCategoryID];
            string partManufacturer = @ProducerNames[producerID];

            string partCode = Guid.NewGuid().ToString();

            int quantity = rnd.Next(1, 20);

            return new Product() {
                CarBrand = carBrand,
                CarModel = carModel,
                CarFirstProdYear = fYear,
                CarLastProdYear = lYear,

                Price = price,
                PartName = @partName,
                PartCategory = partCategory,
                PartManufacturer = partManufacturer,
                PartCode = partCode,
                IsAvailable = true,
                QtAvailable = quantity
            };
        }
    }
}

