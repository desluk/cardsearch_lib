using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using static CardSearchApi.YuGiOhCards.YuGiOhEnums;

namespace CardSearchApi
{
    public class ConnectionClass
    {
        #region Private Consts Variables

        private const string Website = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
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
        private static HttpClient httpClient = new HttpClient();
        private static HttpClient imageClient = new HttpClient();
        private string searchName = null;
        private string sortSearchName = null!;
        private bool hasSortTerm = false;
        private SearchTerm SearchTerms = SearchTerm.FuzzySearch;
        private List<Card> cards = new List<Card>();
        private readonly List<string> cardNames = new List<string>();
        #endregion

        #region Public Variables
        public List<Card> GetCardsFound => cards;
        public List<string> GetNameOfCardsFound => cardNames;
        public string GetUrlParameters => CreateUrlParameters();
        #endregion
        
        #region Constructors
        public ConnectionClass(string searchName, SearchTerm term)
        {
            hasSortTerm = false;
            SearchTerms = term;
            this.searchName = searchName;
            httpClient = new HttpClient();
        }
        
        public ConnectionClass(string cardNameToSearch, SearchTerm termToSearchCardBy, string sortSearchName,
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
        }
        #endregion

        #region Public Methods
        public string ConnectToWebsiteWithJson()
        {
            string resultOfConnection = "";
            httpClient.BaseAddress = new Uri(Website);
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
                resultOfConnection = String.Format("Failed: {0}, ({1})", (int)responseMessage.StatusCode,
                    responseMessage.ReasonPhrase);
                httpClient.CancelPendingRequests();
            }

            return resultOfConnection;
        }

        public async Task<CardImageViewer> GetCardImages(Card cardImageToGet)
        {
            CardImageViewer cardViewer = new CardImageViewer(cardImageToGet.card_images);

            imageClient = new HttpClient();
            try
            {
                foreach (CardImage cardImage in cardViewer.CurrentCardImage)
                {
                    cardViewer.SetSmallImage(await imageClient.GetByteArrayAsync(cardImage.image_url_small));
                    cardViewer.SetLargeImage(await imageClient.GetByteArrayAsync(cardImage.image_url));
                }
            }
            catch (Exception e)
            {
                // ignored
            }
            return cardViewer;
        }

        public async Task<List<CardImageViewer>> GetCardImages (List<Card> cardsImagesToGet)
        {
            List<CardImageViewer> cardViewers = new List<CardImageViewer>();
            foreach (Card card in cardsImagesToGet)
            {
                cardViewers.Add(new CardImageViewer(card.card_images));
            }
            imageClient = new HttpClient();
            try
            {
                foreach (CardImageViewer cardImageViewer in cardViewers)
                {
                    foreach (CardImage cardImage in cardImageViewer.CurrentCardImage)
                    {
                        cardImageViewer.SetSmallImage(await imageClient.GetByteArrayAsync(cardImage.image_url_small));
                        cardImageViewer.SetLargeImage(await imageClient.GetByteArrayAsync(cardImage.image_url));
                    }    
                }
                
            }
            catch (Exception e)
            {
                // ignored
            }
            return cardViewers;
        }

        #endregion

        #region Private Methods
        
        private string ResultOfConnection(HttpResponseMessage responseMessage)
        {
            Task<CardFromJson> data = responseMessage.Content.ReadFromJsonAsync<CardFromJson>()!;

            string resultOfConnection = $"Success: Number of cards found: {data.Result.data.Count}";
            cards = data.Result.data;
            
            foreach (Card card in cards)
                cardNames.Add(card.name);
            
            return resultOfConnection;
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
