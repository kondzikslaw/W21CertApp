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

        public abstract void AddNetWeight(string netWeight);

        public abstract void ShowResults();

        public abstract Statistics GetStatistics();

        public abstract void ShowStatistics();
        

        protected void CheckEventDifferenceOfNetWeightTooMuch()
        {
            if(DifferenceOfNetWeightTooMuch != null)
            {
                DifferenceOfNetWeightTooMuch(this, new EventArgs());
            }
        }
    }
}
