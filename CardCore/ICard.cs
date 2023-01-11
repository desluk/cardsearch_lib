namespace CardCore;

public interface ICard
{
    public string GetCardName();

    public string GetCardDescription();

    public byte[] GetCardSmallImage();
    
    public byte[] GetCardLargeImage();

    public void SetCardName(string cardName);

    public void SetCardDescription(string cardDescription);

    public void SetCardSmallImage(byte[] smallImage);

    public void SetCardLargeImage(byte[] largeImage);
}