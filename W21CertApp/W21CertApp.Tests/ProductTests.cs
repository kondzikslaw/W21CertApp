namespace W21CertApp.Tests
{
    public class ProductTests
    {
        [Test]
        public void WhenAddNetWeights_ShouldShowProductsStatistics()
        {
            var product = new Product("Sausage", "Meat", 280);
            product.AddNetWeight(283.2f);
            product.AddNetWeight(276.9f);
            product.AddNetWeight(256.7f);
            product.AddNetWeight(291.4f);
            product.AddNetWeight(286.5f);
            product.AddNetWeight(288.3f);

            var statistics = product.GetStatistics();

            Assert.AreEqual(280.5f, statistics.Average);
            Assert.AreEqual(291.4f, statistics.Max);
            Assert.AreEqual(256.7f, statistics.Min);
        }
    }
}
