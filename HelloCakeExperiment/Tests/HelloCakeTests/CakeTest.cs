namespace HelloCakeTests
{
    using HelloCake.Model;
    using NUnit.Framework;

    [TestFixture]
    public class CakeTest
    {
        [Test]
        public void TestMethod1()
        {
            var cake = new Cake();
            Assert.AreEqual(cake.SayHello(), "Hello Cake");
        }
    }
}
