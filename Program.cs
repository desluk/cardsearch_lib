// See https://aka.ms/new-console-template for more information


using cardsearch_API;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Test");
            string test = Console.ReadLine();
            if (String.CompareOrdinal(test, "test") == 0) ;
            {
              //  ConnectionClass connectionClass = new ConnectionClass("dark Magician","4");
                Console.WriteLine("Connection Class Created");
               // Console.WriteLine(connectionClass.ConnectToWebsiteWithJson());
                Console.ReadLine();

            }
        }
    }
}
