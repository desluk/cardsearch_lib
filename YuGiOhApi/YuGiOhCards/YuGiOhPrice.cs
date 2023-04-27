using CardCore;

namespace CardSearchApi.YuGiOhCards;

public class YuGiOhPrice:ICardPrice
{
    private string marketPrice = String.Empty;
    private string tcgPlayerPrice = String.Empty;
    private string eBayPrice = String.Empty;
    private string amazonPrice = String.Empty;
    private string coolPrice = String.Empty;
    
    public void SetMarketPrice(string marketPrice)
    {
        this.marketPrice = marketPrice;
    }

    public void SetTcgPlayerPrice(string tcgPlayerPrice)
    {
        this.tcgPlayerPrice = tcgPlayerPrice;
    }

    public void SetEbayPrice(string eBayPrice)
    {
        this.eBayPrice = eBayPrice;
    }

    public void SetAmazonPrice(string amazonPrice)
    {
        this.amazonPrice = amazonPrice;
    }

    public void SetCoolStuffPrice(string coolStuffPrice)
    {
        this.coolPrice = coolStuffPrice;
    }

    public double GetMarketPrice()
    {
        return Convert.ToDouble(marketPrice);
    }

    public double GetTcgPlayerPrice()
    {
        return Convert.ToDouble(tcgPlayerPrice);
    }

    public double GetEBayPrice()
    {
        return Convert.ToDouble(eBayPrice);
    }

    public double GetAmazonPrice()
    {
        return Convert.ToDouble(amazonPrice);
    }

    public double GetCoolStuffPrice()
    {
        return Convert.ToDouble(coolPrice);
    }
}