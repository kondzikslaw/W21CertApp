using System.Globalization;

namespace W21CertApp
{
    public class ProductInFile : ProductBase
    {
        public const string fileName = "_results.txt";
        public string fullFileName;

        public ProductInFile(string name, string type, float declaredNetWeight) : base(name, type, declaredNetWeight)
        {
            fullFileName = $"{name}_{declaredNetWeight}g{fileName}";
        }

        public override void AddNetWeight(float netWeight)
        {
            if (netWeight > 0)
            {
                using (var writer = File.AppendText($"{fullFileName}"))
                {
                    writer.WriteLine(netWeight);
                }
            }
            else
            {
                throw new Exception("Net weight can't be 0 or less.");
            }
        }

        public override void AddNetWeight(string netWeight)
        {
            if (float.TryParse(netWeight, out float result))
            {
                AddNetWeight(result);
            }
            else
            {
                throw new Exception("Please type correct weight.");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fullFileName))
            {
                using (var reader = File.OpenText(fullFileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var result = float.Parse(line);
                        statistics.UpdateStats(result);
                        line = reader.ReadLine();
                    }
                }
            }

            return statistics;
        }

        public override void ShowResults()
        {
            string sr = $"Product: {this.Name}\n" +
                $"Type of product: {this.Type}\n" +
                $"Net weight declared by Customer: {this.DeclaredNetWeight}g\n" +
                $"Results: (";
            using (var reader = File.OpenText(fullFileName))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sr += $"{line}; ";
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"{sr}).");
        }

        public override void ShowStatistics()
        {
            var stats = GetStatistics();
            if (stats.Count != 0)
            {
                var differenceOfNetWeight = this.DeclaredNetWeight - stats.Average;

                ShowResults();
                Console.WriteLine($"Product statistics:\n" +
                    $"Total results: {stats.Count}\n" +
                    $"Maximum result: {stats.Max:N2}g\n" +
                    $"Minimum result: {stats.Min:N2}g\n" +
                    $"Average result: {stats.Average:N2}g\n" +
                    $"Difference between Average and Declared Net Weight: {Math.Abs(differenceOfNetWeight):N2}g");
                if (Math.Abs(differenceOfNetWeight) >= 5)
                {
                    CheckEventDifferenceOfNetWeightTooMuch();
                }
            }
            else
            {
                Console.WriteLine($"There's no results for product: {this.Name}.");
            }
        }
    }
}
