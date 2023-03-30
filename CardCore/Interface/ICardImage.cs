namespace CardCore;

public interface ICardImage
{
    public string GetSmallImageUrl();
    public string GetLargeImageUrl();
    public byte[] GetSmallImages();
    public byte[] GetLargeImages();
    public int GetImageId();

    public void SetSmallImageUrl(string smallImageUrl);
    public void SetLargeImageUrl(string largeImageUrl);
    public void SetImageId(int imageId);
    
    public Boolean GetImagesFromUrls();
}