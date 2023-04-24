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
    }
}
