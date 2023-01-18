using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace CardCore;

public abstract class CardBase: ICard
{
    protected string cardName;
    protected string cardDescription;
    protected int cardId;
    
    protected List<ICardSet> cardSets = new List<ICardSet>();
    protected List<ICardImage> cardImages = new List<ICardImage>();
    protected ICardPrice cardPrice;

    public int GetCardId()
    {
        return cardId;
    }
    
    public string GetCardName()
    {
        return cardName;
    }

    public string GetCardDescription()
    {
        return cardDescription;
    }

    public List<ICardImage> GetAllImages()
    {
        return cardImages;
    }

    public virtual ICardImage GetAnImage(string url)
    {
        return cardImages.FirstOrDefault(x => String.CompareOrdinal(x.GetSmallImageUrl(),url) ==0 || String.CompareOrdinal(x.GetLargeImageUrl(),url) ==0)!;
    }

    public virtual ICardSet GetACardSet(int index)
    {
        return cardSets[index];
    }

    public abstract ICardSet GetACardSet(string setName, string setCode);

    public List<ICardSet> GetAllCardSets()
    {
        return cardSets;
    }

    public virtual ICardPrice GetCardPrice()
    {
        return cardPrice;
    }

    public void SetCardName(string cardName)
    {
        this.cardName = cardName;
    }

    public void SetCardDescription(string cardDescription)
    {
        this.cardDescription = cardDescription;
    }

    public virtual void AddAndUpdateCardImage(ICardImage cardImage)
    {
        if (!cardImages.Contains(cardImage))
        {
            cardImages.Add(cardImage);
        }
    }

    public virtual void AddAndUpdateCardSet(ICardSet cardSet)
    {
        if (!cardSets.Contains(cardSet))
        {
            cardSets.Add(cardSet);
        }
    }

    public void SetCardPrice(ICardPrice cardPrice)
    {
        this.cardPrice = cardPrice;
    }
    
    public abstract void CreateCardFromJson(JToken jsonObject);
    public abstract void CreateCardFromJsonString(string jsonString);

}