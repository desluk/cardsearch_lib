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

    public void AddCardToMainDeck(CardBase cardToAdd);

    public void RemoveCardFromMainDeck(CardBase cardToRemove);

    public void RemoveCardFromMainDeck(string cardName);

    public void SetMinCardAmountInMainDeck(int minCardAmount);
    public void SetMaxCardAmountInMainDeck(int maxCardAmount);

    #endregion

    #region General Methods

    public void LoadDecksFromFile(JToken jsonObject);

    public void SaveDecksToFile();

    #endregion
}