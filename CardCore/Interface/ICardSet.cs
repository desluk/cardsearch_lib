namespace CardCore;

public interface ICardSet
{
    public void SetSetName(string setName);
    public void SetSetCode(string setCode);
    public void SetSetRarity(string setRarity);
    public void SetSetRarityCode(string setRarityCode);
    public void SetSetPrice(string setPrice);
    
    public string GetSetName();
    public string GetSetCode();
    public string GetSetRarity();
    public string GetRarityCode();
    public string GetStringPrice();
    public double GetActualPrice();
}