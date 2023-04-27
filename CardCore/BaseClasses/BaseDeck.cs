using Newtonsoft.Json.Linq;

namespace CardCore;

public abstract class BaseDeck : IDeck
{
    public string DeckName { get; set; }
    public string DeckDescription { get; set; }

    private Dictionary<CardBase, int> mainDeck = new Dictionary<CardBase, int>();
    private int maxNumberOfCardDuplicates;

    protected BaseDeck(int maxNumberOfCardDuplicates, string deckName, string deckDescription)
    {
        this.maxNumberOfCardDuplicates = maxNumberOfCardDuplicates;
        DeckName = deckName;
        DeckDescription = deckDescription;
        maxNumberOfCardDuplicates = 3;
    }

    protected BaseDeck(int maxNumberOfCardDuplicates, string deckName)
    {
        this.maxNumberOfCardDuplicates = maxNumberOfCardDuplicates;
        DeckName = deckName;
        DeckDescription = string.Empty;
        maxNumberOfCardDuplicates = 3;
    }
    
    protected BaseDeck(int maxNumberOfCardDuplicates)
    {
        this.maxNumberOfCardDuplicates = maxNumberOfCardDuplicates;
        DeckName = String.Empty;
        DeckDescription = String.Empty;
        maxNumberOfCardDuplicates = 3;
    }
    
    public Dictionary<CardBase, int> GetMainDeck()
    {
        return mainDeck;
    }

    public CardBase GetCardFromMainDeck(string cardName)
    {
        foreach (KeyValuePair<CardBase, int> pair in mainDeck)
        {
            if (String.CompareOrdinal(cardName, pair.Key.cardName) == 0)
            {
                return pair.Key;
            }
        }

        return null;
    }

    public abstract void SetMainDeck(JToken jsonObject);

    public void AddCardToMainDeck(CardBase cardToAdd)
    {
        foreach (KeyValuePair<CardBase, int> pair in mainDeck)
        {

            if (String.CompareOrdinal(cardToAdd.cardName, pair.Key.cardName) == 0)
            {
                if (pair.Value >= maxNumberOfCardDuplicates)
                    return;
                mainDeck[cardToAdd] += 1;
                return;
            }
        }

        mainDeck.Add(cardToAdd, 1);
    }

    public void RemoveCardFromMainDeck(CardBase cardToRemove)
    {
       RemoveCardFromMainDeck(cardToRemove.cardName);
    }

    public void RemoveCardFromMainDeck(string cardName)
    {
        CardBase tempCard = null;
        foreach (KeyValuePair<CardBase, int> pair in mainDeck)
        {
            if (String.CompareOrdinal(cardName, pair.Key.cardName) == 0)
            {
                if (pair.Value > 1)
                {
                    mainDeck[pair.Key] -= 1;
                    return;
                }
                else
                {
                    tempCard = pair.Key;
                    return;
                }
            }
        }

        if (tempCard != null) 
            mainDeck.Remove(tempCard);
    }


    public abstract void SetMinCardAmountInMainDeck(int minCardAmount);

    public abstract void SetMaxCardAmountInMainDeck(int maxCardAmount);

    public abstract void LoadDecksFromFile(JToken jsonObject);

    public abstract void SaveDecksToFile();
}
