namespace CardCore;

public abstract class CardBase: ICard
{
    private string cardName;
    private string cardDescription;
    private byte[] smallImage;
    private byte[] largeImage;
    
    public string GetCardName()
    {
        return cardName;
    }

    public string GetCardDescription()
    {
        return cardDescription;
    }

    public byte[] GetCardSmallImage()
    {
        return smallImage;
    }

    public byte[] GetCardLargeImage()
    {
        return largeImage;
    }

    public void SetCardName(string cardName)
    {
        this.cardName = cardName;
    }

    public void SetCardDescription(string cardDescription)
    {
        this.cardDescription = cardDescription;
    }

    public void SetCardSmallImage(byte[] smallImage)
    {
        this.smallImage = smallImage;
    }

    public void SetCardLargeImage(byte[] largeImage)
    {
        this.largeImage = largeImage;
    }
}