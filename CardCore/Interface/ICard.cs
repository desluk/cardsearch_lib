using System.Text.Json.Nodes;

namespace CardCore;

public interface ICard
{
#region Get Methods
    public int GetCardId();
    public string GetCardName();
    public string GetCardDescription();
    public List<ICardImage> GetAllImages();
    public ICardImage GetAnImage(string url);
    public ICardSet GetACardSet(int index);    
    public ICardSet GetACardSet(string setName, string setCode);
    public List<ICardSet> GetAllCardSets();
    public ICardPrice GetCardPrice();
#endregion

#region Set Methods
    public void SetCardName(string cardName);
    public void SetCardDescription(string cardDescription);

    public void AddAndUpdateCardImage(ICardImage cardImage);
    public void AddAndUpdateCardSet(ICardSet cardSet);
    public void SetCardPrice(ICardPrice cardPrice);
#endregion 
    
    public void CreateCardFromJson(JsonObject jsonObject);
    
}