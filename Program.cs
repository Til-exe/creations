using Gruppenprojekt.App;

namespace Gruppenprojekt
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (GameWindow gw = new GameWindow())
            {
                gw.Run();
            }
        }
    }
}