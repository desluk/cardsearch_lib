using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace cardsearch_API
{
    public class ConnectionClass
    {
        #region Private Consts Variables

        private string website = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        private string questionMark = "?";
        private string fuzzySearch = "fname";
        private string archetype = "archetype";
        private string sort = "sort";
        private string andSign = "&";
        private string attribute = "attribute";
        private string equals = "=";
        private string level = "level";
        private string format = "format";
        private string cardSet = "cardset";

        #endregion

        #region Private Variables

        private static HttpClient client = new HttpClient();
        private string searchName;
        private searchTerm searchTerms;
        private string sortSearchName;
        private bool hasSortTerm;
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
            string final = "";
            client.BaseAddress = new Uri(website);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseMessage = client.GetAsync(GetUrlParameters()).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                Task<CardFromJson> data = responseMessage.Content.ReadFromJsonAsync<CardFromJson>()!;

            }
            else
            {
                final = String.Format("Failed: {0}, ({1})", (int)responseMessage.StatusCode,
                    responseMessage.ReasonPhrase);

            }

            return final;
        }

        #endregion

        #region Private Methods

        private string GetUrlParameters()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(questionMark);

            switch (searchTerms)
            {
                case searchTerm.attributeSearch:
                    stringBuilder.Append(attribute);
                    break;
                case searchTerm.cardsetSearch:
                    stringBuilder.Append(card)
            }
            if (hasSortTerm)
            {
                
            }
            return final;
        }

        #endregion

    }
}
