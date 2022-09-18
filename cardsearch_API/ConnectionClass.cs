using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace cardsearch_API
{
    public class ConnectionClass
    {
        #region Private Consts Variables

        private const string website = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        private const string questionMark = "?";
        private string fuzzySearch = "fname";
        private string directNameSearch = "name";
        private string archetype = "archetype";
        private string sort = "sort";
        private string andSign = "&";
        private string attribute = "attribute";
        private string equals = "=";
        private string level = "level";
        private string format = "format";
        private string cardSet = "cardset";
        private string typesearch = "type";

        #endregion

        #region Private Variables
        private static HttpClient client = new HttpClient();
        private string searchName;
        private searchTerm searchTerms;
        private string sortSearchName = null!;
        private bool hasSortTerm;
        private ConverterForEnums ConverterForEnums = new ConverterForEnums();
        private List<Card> cards = new List<Card>();
        private List<string> cardNames = new List<string>();
        #endregion


        #region Public Variables

        public List<Card> GetCardsFound => cards;
        public List<string> GetNameOfCardsFound => cardNames;
        #endregion
        
        #region Constructors

        public ConnectionClass(string searchName, searchTerm term)
        {
            hasSortTerm = false;
            this.searchTerms = term;
            this.searchName = searchName;
        }
        
        public ConnectionClass(string searchName, searchTerm termToSearchBy, string sortSearchName,
            bool sort = false)
        {
            this.searchName = searchName;
            this.searchTerms = termToSearchBy;
            hasSortTerm = sort;
            if (hasSortTerm)
            {
                this.sortSearchName = sortSearchName;
            }

        }
        #endregion

        #region Public Methods

        public string ConnectToWebsiteWithJson()
        {
            string resultOfConnection = "";
            client.BaseAddress = new Uri(website);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = client.GetAsync(CreateUrlParameters()).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                Task<CardFromJson> data = responseMessage.Content.ReadFromJsonAsync<CardFromJson>()!;
                resultOfConnection = string.Format("Success: Number of cards found: {0}", data.Result.data.Count);
                cards = data.Result.data;
                foreach (Card card in cards)
                {
                    cardNames.Add(card.name);
                }
            }
            else
            {
                resultOfConnection = String.Format("Failed: {0}, ({1})", (int)responseMessage.StatusCode,
                    responseMessage.ReasonPhrase);
            }

            client.CancelPendingRequests();
            return resultOfConnection;
        }

        public string GetUrlParameters => CreateUrlParameters();
        #endregion

        #region Private Methods

        private string CreateUrlParameters()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(questionMark);

            stringBuilder.Append(ConverterForEnums.ConvertingSearchTermToString(searchTerms));

            stringBuilder.Append(equals);
            stringBuilder.Append(searchName.Replace(" ","%20"));
            
            if (hasSortTerm)
            {
                stringBuilder.Append(andSign);
                stringBuilder.Append(equals);
                stringBuilder.Append(sortSearchName);
            }
            return stringBuilder.ToString();
        }

        #endregion

    }
}
