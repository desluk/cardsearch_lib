namespace CardCore;

public interface ICardPrice
{
    public void SetMarketPrice(string marketPrice);
    public void SetTcgPlayerPrice(string tcgPlayerPrice);
    public void SetEbayPrice(string eBayPrice);
    public void SetAmazonPrice(string amazonPrice);
    public void SetCoolStuffPrice(string coolStuffPrice);

    public double GetMarketPrice();
    public double GetTcgPlayerPrice();
    public double GetEBayPrice();
    public double GetAmazonPrice();
    public double GetCoolStuffPrice();
}