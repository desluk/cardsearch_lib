using Newtonsoft.Json.Linq;

namespace CardCore;

public interface ICard
{
#region Get Methods
public string GetCardDescription();
    public List<ICardImage> GetAllImages();
    public ICardImage GetAnImage(string url);
    public ICardSet GetACardSet(int index);    
    public ICardSet GetACardSet(string setName, string setCode);
    public List<ICardSet> GetAllCardSets();
    public ICardPrice GetCardPrice();
#endregion

#region Set Methods
public void SetCardDescription(string cardDescription);

    public void AddAndUpdateCardImage(ICardImage cardImage);
    public void AddAndUpdateCardSet(ICardSet cardSet);
    public void SetCardPrice(ICardPrice cardPrice);
#endregion 
    
    public void CreateCardFromJson(JToken jsonObject);

    public void CreateCardFromJsonString(string jsonString);

}