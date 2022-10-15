namespace CardSearchApi;

public class CardImage
{
    public int id { get; set; }
    public string? image_url { get; set; }
    public string? image_url_small { get; set; }
}

public class CardImageViewer
{
    private List<CardImage> cardImages;
    private List<byte[]> smallImages;
    private List<byte[]> largeImages;
    public List<CardImage> CurrentCardImage => cardImages;
    public List<byte[]> LargeImage => largeImages;

    public List<byte[]> SmallImage => smallImages;

    public CardImageViewer(List<CardImage> cardImages)
    {
        this.cardImages = cardImages;
        smallImages = new List<byte[]>();
        largeImages = new List<byte[]>();
    }

    public void SetSmallImage(byte[] smallImage)
    {
        if(!smallImages.Contains(smallImage))
            smallImages.Add(smallImage);
    }

    public void SetLargeImage(byte[] largeImage)
    {
        if(!largeImages.Contains(largeImage))
            largeImages.Add(largeImage);
    }
}