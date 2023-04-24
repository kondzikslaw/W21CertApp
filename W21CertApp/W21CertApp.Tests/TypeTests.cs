namespace W21CertApp.Tests
{
    public class TypeTests
    {
        [Test]
        public void WhenInitializeTwoProducts_ShouldReturnDifferentObject()
        {
            var product1 = new Product("Sausage", "Meat", 350);
            var product2 = new Product("Lollipop", "Sweets", 10);

            Assert.AreNotEqual(product1, product2);
            Assert.False(product1.Equals(product2));
            Assert.False(Object.ReferenceEquals(product1, product2));
        }

        [Test]
        public void WhenInitializeOneProduct_ShouldSecondProductReferenceFirstOne()
        {
            var product1 = new Product("Sausage", "Meat", 350);
            var product2 = product1;

            Assert.AreEqual(product1, product2);
            Assert.True(product1.Equals(product2));
            Assert.True(Object.ReferenceEquals(product1, product2));
        }
    }
}
