namespace W21CertApp
{
    public class Product : ProductBase
    {
        public List<float> netWeights = new List<float>();

        public Product(string name, string type, float declaredNetWeight)
            :base(name, type, declaredNetWeight)
        {
        }

        public override void AddNetWeight(float netWeight)
        {
            if (netWeight > 0)
            {
                this.netWeights.Add(netWeight);
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
        public override void ShowResults()
        {
            string sr = $"Product: {this.Name}\n" +
                $"Type of product: {this.Type}\n" +
                $"Net weight declared by Customer: {this.DeclaredNetWeight}g\n" +
                $"Results: (";
            for(int i = 0;  i < netWeights.Count; i++)
            {
                if (i == netWeights.Count - 1)
                {
                    sr += $"{netWeights[i]}g)";
                }
                else
                {
                    sr += $"{netWeights[i]}g; ";
                }
            }
            Console.WriteLine($"{sr}.");
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var netWeight in netWeights)
            {
                statistics.UpdateStats(netWeight);
            }

            return statistics;
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
