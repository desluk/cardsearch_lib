using Newtonsoft.Json.Linq;

namespace BasicConnection.Connections.Interfaces;

public interface ICardConnection
{
    public void SetUrl(string url);
    public JToken ConnectToWebsiteWithJson();

    public byte[] GetImageFromImageUrl(string imageUrl);
    
    public Dictionary<String,byte[]> GetImagesFromListOfUrl(List<string> imageUrls);
}