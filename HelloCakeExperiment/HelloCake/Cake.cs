namespace HelloCake.Model
{
    using Interfaces;
    public class Cake : ICake
    {
        public string SayHello()
        {
            return "Hello Cake";
        }
    }
}
