using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using CardSearchApi.YuGiOhCards;
using Newtonsoft.Json.Linq;
using BasicConnection;
using static CardSearchApi.YuGiOhCards.YuGiOhEnums;

namespace CardSearchApi
{
    public class YuGiOhConnection:BaseCardConnection
    {
        #region Private Consts Variables
        private const string QuestionMark = "?";
        private const string FuzzySearch = "fname";
        private const string DirectNameSearch = "name";
        private const string Archetype = "archetype";
        private const string Sort = "sort";
        private const string AndSign = "&";
        private const string Attribute = "attribute";
        private const string EqualSign = "=";
        private const string Level = "level";
        private const string Format = "format";
        private const string CardSet = "cardset";
        private const string TypeSearch = "type";

        #endregion

        #region Private Variables
        private string searchName = null;
        private string sortSearchName = null!;
        private bool hasSortTerm = false;
        private SearchTerm SearchTerms = SearchTerm.FuzzySearch;
        private readonly List<string> cardNames = new List<string>();
        #endregion

        #region Public Variables
        public List<string> GetNameOfCardsFound => cardNames;
        public string GetUrlParameters => CreateUrlParameters();
        #endregion
        
        #region Constructors
        public YuGiOhConnection(string searchName, SearchTerm term)
        {
            hasSortTerm = false;
            SearchTerms = term;
            this.searchName = searchName;
            httpClient = new HttpClient();
            apiUrl = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        }
        
        public YuGiOhConnection(string cardNameToSearch, SearchTerm termToSearchCardBy, string sortSearchName,
            bool sort = false)
        {
            searchName = cardNameToSearch;
            SearchTerms = termToSearchCardBy;
            hasSortTerm = sort;
            if (hasSortTerm)
            {
                this.sortSearchName = sortSearchName;
            }
            httpClient = new HttpClient();
            apiUrl = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        }
        
        
        #endregion

        #region Public Methods
        public override JToken ConnectToWebsiteWithJson()
        {
            JToken? resultOfConnection = null;
            httpClient.BaseAddress = new Uri(apiUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage responseMessage = httpClient.GetAsync(CreateUrlParameters()).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                resultOfConnection = ResultOfConnection(responseMessage);
                httpClient.CancelPendingRequests();
            }
            else
            {
               
                httpClient.CancelPendingRequests();
            }
            
            return resultOfConnection;
        }

        public override byte[] GetImageFromImageUrl(string imageUrl)
        {
            byte[] imageArray = new byte[] { };

            return imageArray;  
        }

        public override Dictionary<string, byte[]> GetImagesFromListOfUrl(List<string> imageUrls)
        {
            Dictionary<string, byte[]> imageArray = new Dictionary<string, byte[]>();

            return imageArray;
        }

        // public async Task<CardImageViewer> GetCardImages(Card cardImageToGet)
        // {
        //     CardImageViewer cardViewer = new CardImageViewer(cardImageToGet.card_images);
        //
        //     imageClient = new HttpClient();
        //     try
        //     {
        //         foreach (CardImage cardImage in cardViewer.CurrentCardImage)
        //         {
        //             cardViewer.SetSmallImage(await imageClient.GetByteArrayAsync(cardImage.image_url_small));
        //             cardViewer.SetLargeImage(await imageClient.GetByteArrayAsync(cardImage.image_url));
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         // ignored
        //     }
        //     return cardViewer;
        // }
        //
        // public async Task<List<CardImageViewer>> GetCardImages (List<Card> cardsImagesToGet)
        // {
        //     List<CardImageViewer> cardViewers = new List<CardImageViewer>();
        //     foreach (Card card in cardsImagesToGet)
        //     {
        //         cardViewers.Add(new CardImageViewer(card.card_images));
        //     }
        //     imageClient = new HttpClient();
        //     try
        //     {
        //         foreach (CardImageViewer cardImageViewer in cardViewers)
        //         {
        //             foreach (CardImage cardImage in cardImageViewer.CurrentCardImage)
        //             {
        //                 cardImageViewer.SetSmallImage(await imageClient.GetByteArrayAsync(cardImage.image_url_small));
        //                 cardImageViewer.SetLargeImage(await imageClient.GetByteArrayAsync(cardImage.image_url));
        //             }    
        //         }
        //         
        //     }
        //     catch (Exception e)
        //     {
        //         // ignored
        //     }
        //     return cardViewers;
        // }

        #endregion

        #region Private Methods
        
        private  JToken? ResultOfConnection(HttpResponseMessage responseMessage)
        {
           return  JToken.Parse(responseMessage.Content.ReadFromJsonAsync<JsonObject>().Result!.ToJsonString());
        }


        private string CreateUrlParameters()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(QuestionMark);

            stringBuilder.Append(ConvertingSearchTermToString(SearchTerms));

            stringBuilder.Append(EqualSign);
            stringBuilder.Append(searchName.Replace(" ","%20"));
            
            if (hasSortTerm)
            {
                stringBuilder.Append(AndSign);
                stringBuilder.Append(EqualSign);
                stringBuilder.Append(sortSearchName);
            }
            return stringBuilder.ToString();
        }

        #endregion

    }
}
