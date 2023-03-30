using Newtonsoft.Json.Linq;

namespace CardCore;

public abstract class BaseDeck: IDeck
{
    private Dictionary<CardBase,int> mainDeck = new Dictionary<CardBase,int>();
    private int maxNumberOfCardDuplicates;

    protected BaseDeck(int maxNumberOfCardDuplicates)
    {
        this.maxNumberOfCardDuplicates = maxNumberOfCardDuplicates;
    }

    public Dictionary<CardBase,int> GetMainDeck()
    {
        return mainDeck;
    }

    public CardBase GetCardFromMainDeck(string cardName)
    {
        foreach (KeyValuePair<CardBase,int> pair in mainDeck)
        {
            if (String.CompareOrdinal(cardName, pair.Key.cardName) == 0)
            {
                return pair.Key;
            }
        }

        return null;
    }

    public abstract void SetMainDeck(JToken jsonObject);

    public void AddCard(CardBase CardToAdd)
    {
        foreach (KeyValuePair<CardBase,int> pair in mainDeck)
        {
            
            if (String.CompareOrdinal(CardToAdd.cardName, pair.Key.cardName) == 0)
            {
                if (pair.Value >= maxNumberOfCardDuplicates)
                    return;
                mainDeck[CardToAdd] += 1;
                return;
            }
        }
        mainDeck.Add(CardToAdd,1);
    }
}