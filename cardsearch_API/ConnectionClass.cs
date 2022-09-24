using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

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
        private static HttpClient s_client = new HttpClient();
        private string searchName;
        private searchTerm searchTerms;
        private string sortSearchName = null!;
        private bool hasSortTerm;
        private readonly ConverterForEnums converterForEnums = new ConverterForEnums();
        private List<Card> cards = new List<Card>();
        private readonly List<string> cardNames = new List<string>();
        #endregion


        #region Public Variables

        public List<Card> GetCardsFound => cards;
        public List<string> GetNameOfCardsFound => cardNames;
        public string GetUrlParameters => CreateUrlParameters();
        #endregion
        
        #region Constructors

        public ConnectionClass(string searchName, searchTerm term)
        {
            hasSortTerm = false;
            this.searchTerms = term;
            this.searchName = searchName;
            s_client = new HttpClient();
        }
        
        public ConnectionClass(string cardNameToSearch, searchTerm termToSearchCardBy, string sortSearchName,
            bool sort = false)
        {
            searchName = cardNameToSearch;
            searchTerms = termToSearchCardBy;
            hasSortTerm = sort;
            if (hasSortTerm)
            {
                this.sortSearchName = sortSearchName;
            }
            s_client = new HttpClient();
        }
        #endregion

        #region Public Methods

        public string ConnectToWebsiteWithJson()
        {
            string resultOfConnection = "";
            s_client.BaseAddress = new Uri(Website);
            s_client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = s_client.GetAsync(CreateUrlParameters()).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                resultOfConnection = ResultOfConnection(responseMessage);
                s_client.CancelPendingRequests();
            }
            else
            {
                resultOfConnection = String.Format("Failed: {0}, ({1})", (int)responseMessage.StatusCode,
                    responseMessage.ReasonPhrase);
                s_client.CancelPendingRequests();
            }

            return resultOfConnection;
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

            stringBuilder.Append(converterForEnums.ConvertingSearchTermToString(searchTerms));

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
