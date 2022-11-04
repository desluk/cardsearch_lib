// See https://aka.ms/new-console-template for more information

using CardSearchApi;

static class Program
{
    static readonly string lineBreak = "<================================================================>";
    static void Main(string[] args)
    {
        Console.WriteLine("This is a termanel version of the Yu-gi-Oh card search");
        LineBreak();
        string? cont = null;
        double timeTakenToRun = 0.0;
        bool continueSearching = true;
        
        do
        {
            Console.WriteLine("Type in the search term your want");
            Console.WriteLine("Please choose one of the following items to use as a search request. If you press enter with nothing or in incorrect item it will be fuzzy search used.");
            WriteSearchEnumsToTheScreen();
            searchTerm searchTerm = ConverterForEnums.ConvertStringToSearchTerm(Console.ReadLine());
            LineBreak();
            Console.WriteLine("You are using " + searchTerm);
            Console.WriteLine("Type in the card name/search name you are wanting, if you do not enter anything ");
            string searchName = GetCardNameFromUser();

            ConnectionClass connectionClass = new ConnectionClass(searchName, searchTerm);
            Console.WriteLine("Connection Class Created");
            
            connectionClass.ConnectToWebsiteWithJson();
            Console.WriteLine("If you want to get the card details. Please enter y/yes");
            cont = Console.ReadLine().ToLower() ;
            if (cont != null)
            {
                DisplayCardInformation(cont, connectionClass);
            }
            else
            {
                foreach (Card card in connectionClass.GetCardsFound)
                {
                    Console.WriteLine(lineBreak);
                    Console.WriteLine("Name: " + card.name);
                }
            }
            LineBreak();
            Console.WriteLine("Number of items found with your search: " + connectionClass.GetCardsFound.Count);
            
            cont = null;
            Console.WriteLine("If you want the Images for the cards please press y/yes");
            cont = Console.ReadLine().ToLower();
            if (FindIfPlacedInYes(cont))
            {
                LineBreak();
                Console.WriteLine("Get first cards image");
                Task<CardImageViewer> test = connectionClass.GetCardImages(connectionClass.GetCardsFound[0]);
                CardImageViewer cardImageViewer = test.Result;
                LineBreak();
                Console.WriteLine("Number of items found for large Images: "+cardImageViewer.LargeImage.Count);
                Console.WriteLine("Number of items found for Small Images: "+cardImageViewer.SmallImage.Count);
                Console.ReadLine();
            }
            
            LineBreak();
            Console.WriteLine("Please press enter to look for another card or press q/quit to exit");
            
            string? quit = Console.ReadLine().ToLower();
            if (quit != null)
            {
                if (quit == "q" || quit == "quit" || quit == "q/quit")
                    continueSearching = false;
            }
            
        } while (continueSearching);
        
        LineBreak();
        Console.WriteLine("Thank you for trying out this small program");
        Console.ReadLine();
    }

    private static void LineBreak()
    {
        Console.WriteLine(lineBreak);
        Console.WriteLine();
    }

    private static void DisplayCardInformation(string cont, ConnectionClass connectionClass)
    {
        if (FindIfPlacedInYes(cont))
        {
            foreach (Card card in connectionClass.GetCardsFound)
                WriteCardDetails(card);
        }
        else
        {
            foreach (Card card in connectionClass.GetCardsFound)
            {
                LineBreak();
                Console.WriteLine("Name: " + card.name);
            }
        }
    }

    private static bool FindIfPlacedInYes(string cont)
    {
        return cont == "y" || cont == "yes" || cont == "y/yes";
    }

    private static void WriteCardDetails(Card card)
    {
        LineBreak();
        Console.WriteLine("Name: " + card.name);
        Console.WriteLine();
        Console.WriteLine("Description: " + card.desc);
        Console.WriteLine();
        Console.WriteLine("Attack: " + card.atk + " Defence: " + card.def);
    }

    private static string GetCardNameFromUser()
    {
        string? searchName = Console.ReadLine();

        if (searchName == null || searchName == " " || searchName == "")
        {
            Console.WriteLine("You are searching Dark Magician");
            searchName = "Dark Magician";
        }

        return searchName;
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