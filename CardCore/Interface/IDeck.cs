using Newtonsoft.Json.Linq;

namespace CardCore;

public interface IDeck
{
    #region Get Methods

    public Dictionary<CardBase,int> GetMainDeck();

    public CardBase GetCardFromMainDeck(string cardName);
    #endregion

    #region Set Methods

    public void SetMainDeck(JToken jsonObject);

    public void AddCard(CardBase CardToAdd);
    
    #endregion
}