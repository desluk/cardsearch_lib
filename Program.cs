// See https://aka.ms/new-console-template for more information

using CardCore;
using CardSearchApi;
using CardSearchApi.Debug;
using CardSearchApi.YuGiOhCards;
using Newtonsoft.Json.Linq;


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
            Console.WriteLine("Testing the DebugLog");
            
            DebugLog.WriteDebugLog("This is a test of debug system");

            LineBreak();
            Console.WriteLine("Type in the search term your want");
            Console.WriteLine("Please choose one of the following items to use as a search request. If you press enter with nothing or in incorrect item it will be fuzzy search used.");
            WriteSearchEnumsToTheScreen();
            SearchTerm searchTerm = YuGiOhEnums.ConvertStringToSearchTerm(Console.ReadLine());
            LineBreak();
            Console.WriteLine("You are using " + searchTerm);
            Console.WriteLine("Type in the card name/search name you are wanting, if you do not enter anything ");
            string searchName = GetCardNameFromUser();

            YuGiOhConnection connectionClass = new YuGiOhConnection(searchName, searchTerm);
            Console.WriteLine("Connection Class Created");
            
           JToken? test = connectionClass.ConnectToWebsiteWithJson();
           List<CardBase> listOfCards = new List<CardBase>();
           if (test != null)
           {
               JArray check = (JArray)test["data"]!;
               foreach (JToken jToken in check)
               {
                   YuGiOhCard card = new YuGiOhCard();
                   card.CreateCardFromJson(jToken);
                   listOfCards.Add(card);
               }
           }
          
            LineBreak();
            Console.WriteLine("Number of items found with your search: " + listOfCards.Count);
            Console.WriteLine("Do you want to see the card details? Press y/yes");
            cont = Console.ReadLine();
            DisplayCardInformation(cont,listOfCards);
            
            cont = null;
            Console.WriteLine("If you want the Images for the cards please press y/yes");
            cont = Console.ReadLine().ToLower();
            if (FindIfPlacedInYes(cont))
            {
                LineBreak();
                Console.WriteLine("Get first cards image");
                List<byte[]> allTheImages = new List<byte[]>();

                foreach (CardBase listOfCard in listOfCards)
                {
                    if(allTheImages.Count == 10)
                        break;
                    
                    foreach (ICardImage cardImage in listOfCard.GetAllImages())
                    {
                        if(cardImage!= null && cardImage.GetLargeImageUrl() != "")
                            allTheImages.Add(connectionClass.GetImageFromImageUrl(cardImage.GetLargeImageUrl()));
                    }
                }

                WriteImagesToFile(allTheImages);
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

    private static void WriteImagesToFile(List<byte[]> allTheImages)
    {
        int number = 0;
        foreach (byte[] image in allTheImages)
        {
            using (MemoryStream ms = new MemoryStream(image))
            {
                using (FileStream fs = new FileStream("/home/luke/Documents/Cards_"+number, FileMode.Create))
                {
                    ms.WriteTo(fs);
                    Console.WriteLine("Card has been written to the following location: "+"/home/luke/Documents/Cards_"+number);
                }
            }

            number++;
        }
    }

    private static void LineBreak()
    {
        Console.WriteLine(lineBreak);
        Console.WriteLine();
    }

    private static void DisplayCardInformation(string cont, List<CardBase> cards)
    {
        if (FindIfPlacedInYes(cont))
        {
            foreach (CardBase card in cards)
                WriteCardDetails(card);
        }
        else
        {
            foreach (CardBase card in cards)
            {
                LineBreak();
                Console.WriteLine("Name: " + card.cardName);
            }
        }
    }

    private static bool FindIfPlacedInYes(string cont)
    {
        return cont == "y" || cont == "yes" || cont == "y/yes";
    }

    private static void WriteCardDetails(CardBase card)
    {
        
        LineBreak();
        Console.WriteLine("Name: " + card.cardName);
        Console.WriteLine();
        Console.WriteLine("Description: " + card.GetCardDescription());
        Console.WriteLine();
        if(card is YuGiOhCard yu)
            Console.WriteLine("Attack: " + yu.GetAttack() + " Defence: " + yu.GetDefense());
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