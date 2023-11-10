namespace ProductService.Test.Isolation
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            Random random = new Random();
            int number = random.Next();

            Assert.True(number < 10000000);

        }
    }
}