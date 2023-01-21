using BasicConnection.Connections.Interfaces;
using Newtonsoft.Json.Linq;

namespace BasicConnection;

public abstract class BaseCardConnection: ICardConnection
{
    protected string apiUrl;
    
    protected HttpClient httpClient;
    protected HttpClient imageClient;
    
    
    public void SetUrl(string url)
    {
        apiUrl = url;
    }

    public abstract JToken ConnectToWebsiteWithJson();

    public abstract byte[] GetImageFromImageUrl(string imageUrl);

    public abstract Dictionary<string, byte[]> GetImagesFromListOfUrl(List<string> imageUrls);

}