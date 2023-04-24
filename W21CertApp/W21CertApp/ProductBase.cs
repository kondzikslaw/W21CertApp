namespace W21CertApp
{
    public abstract class ProductBase : IProduct
    {
        public delegate void DifferenceOfNetWeightTooMuchDelegate(object sender, EventArgs args);

        public event DifferenceOfNetWeightTooMuchDelegate DifferenceOfNetWeightTooMuch;
        public ProductBase(string name, string type, float declaredNetWeight)
        {
            this.Name = name;
            this.Type = type;
            this.DeclaredNetWeight = declaredNetWeight;
        }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public float DeclaredNetWeight { get; private set; }

        public abstract void AddNetWeight(float netWeight);

        public void AddNetWeight(string netWeight)
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

        public abstract void ShowResults();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
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
        

        protected void CheckEventDifferenceOfNetWeightTooMuch()
        {
            if(DifferenceOfNetWeightTooMuch != null)
            {
                DifferenceOfNetWeightTooMuch(this, new EventArgs());
            }
        }
    }
}
