// See https://aka.ms/new-console-template for more information


using cardsearch_API;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
         ConverterForEnums converterForEnums = new ConverterForEnums();
            Console.WriteLine("The Test");
            string test = Console.ReadLine();
            if (String.CompareOrdinal(test, "test") == 0) ;
            {
                while (true)
                {
                    Console.WriteLine("Type in the search term your want");
                    string searchTerm = Console.ReadLine();
                    if (searchTerm == null || searchTerm == " " || searchTerm == "")
                    {
                        Console.WriteLine("You are using fuzzy search");
                        searchTerm = "fname";
                    }


                    Console.WriteLine("Type in the card name/search name you are wanting");
                    string searchName = Console.ReadLine();
                    if (searchName == null || searchName == " " || searchName == "")
                    {
                        Console.WriteLine("You are searching Dark Magician");
                        searchName = "Dark Magician";
                    }

                    ConnectionClass connectionClass = new ConnectionClass(searchName,
                        converterForEnums.ConvertStringToSearchTerm(searchTerm));
                    Console.WriteLine("Connection Class Created");
                    Console.WriteLine(connectionClass.ConnectToWebsiteWithJson());
                    
                    
                }
            }
        }
    }
}
