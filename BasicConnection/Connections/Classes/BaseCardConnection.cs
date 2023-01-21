using BasicConnection.Connections.Interfaces;
using Newtonsoft.Json.Linq;

namespace BasicConnection;

public abstract class BaseCardConnection: ICardConnection
{
    protected string apiUrl;
    protected static HttpClient httpClient = new HttpClient();
    protected static HttpClient imageClient = new HttpClient();
    
    
    public void SetUrl(string url)
    {
        apiUrl = url;
    }

    public abstract JToken ConnectToWebsiteWithJson();

    public abstract byte[] GetImageFromImageUrl(string imageUrl);

    public abstract Dictionary<string, byte[]> GetImagesFromListOfUrl(List<string> imageUrls);

}