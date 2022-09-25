// See https://aka.ms/new-console-template for more information

using CardSearchApi;

static class Program
{
    static void Main(string[] args)
    {
        ConverterForEnums converterForEnums = new ConverterForEnums();
        Console.WriteLine("This is a termanel version of the Yu-gi-Oh card search");
        double timeTakenToRun = 0.0;
        bool continueSearching = true;
        do
        {
            Console.WriteLine("Type in the search term your want");
            Console.WriteLine(
                "Please choose one of the following items to use as a search request. If you press enter with nothing or in incorrect item it will be fuzzy search used.");
            WriteSearchEnumsToTheScreen();
            searchTerm searchTerm = new ConverterForEnums().ConvertStringToSearchTerm(Console.ReadLine());

            Console.WriteLine("You are using " + searchTerm);
            Console.WriteLine("Type in the card name/search name you are wanting, if you do not enter anything ");
            string? searchName = Console.ReadLine();

            if (searchName == null || searchName == " " || searchName == "")
            {
                Console.WriteLine("You are searching Dark Magician");
                searchName = "Dark Magician";
            }

            ConnectionClass connectionClass = new ConnectionClass(searchName, searchTerm);
            Console.WriteLine("Connection Class Created");

            
            connectionClass.ConnectToWebsiteWithJson();
            Console.WriteLine("If you want to get the card details. Please enter y/yes");
            string? cont = Console.ReadLine();
            if (cont != null)
            {
                if (cont.ToLower() == "y" || cont.ToLower() == "yes" || cont.ToLower() == "y/yes")
                {
                    foreach (Card card in connectionClass.GetCardsFound)
                    {
                        Console.WriteLine("<================================================================>");
                        Console.WriteLine("Name: " + card.name);
                        Console.WriteLine();
                        Console.WriteLine("Description: " + card.desc);
                        Console.WriteLine();
                        Console.WriteLine("Attack: " + card.atk + " Defence: " + card.def);
                    }
                }
                else
                {
                    foreach (Card card in connectionClass.GetCardsFound)
                    {
                        Console.WriteLine("<================================================================>");
                        Console.WriteLine("Name: " + card.name);
                    }
                }
            }
            else
            {
                foreach (Card card in connectionClass.GetCardsFound)
                {
                    Console.WriteLine("<================================================================>");
                    Console.WriteLine("Name: " + card.name);
                }
            }

            Console.WriteLine("<================================================================>");
            Console.WriteLine("Number of items found with your search: " + connectionClass.GetCardsFound.Count);
            Console.WriteLine();
            Console.WriteLine("Please press enter to look for another card or press q/quit to exit");
            
            string? quit = Console.ReadLine();
            if (quit != null)
            {
                if (quit.ToLower() == "q" || quit.ToLower() == "quit" || quit.ToLower() == "q/quit")
                    continueSearching = false;
            }
        } while (continueSearching);
        Console.WriteLine("Thank you");
        Console.ReadLine();
    }

    private static void WriteSearchEnumsToTheScreen()
    {
        Console.WriteLine();
        Console.WriteLine("Fuzzy Search");
        Console.WriteLine("Name Search");
        Console.WriteLine("Type Search");
        Console.WriteLine("Attribute Search");
        Console.WriteLine("Card Set Search");
        Console.WriteLine("Format Search");
        Console.WriteLine("Stable Search");
        Console.WriteLine("Archetype Search");
        Console.WriteLine();
    }
}