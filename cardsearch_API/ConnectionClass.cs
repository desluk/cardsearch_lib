

using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.VisualBasic.CompilerServices;

namespace cardsearch_API
{

    public class ConnectionClass
    {
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
        
        

        static HttpClient client = new HttpClient();

        private searchTerm[] toSearch;
        private string[] searchTerms;

        public ConnectionClass(string searchCVS, string termCVS)
        {
            DetermineSearchTypes(searchCVS,termCVS);
        }

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

        private string GetUrlParameters()
        {
            string final = questionMark;
            return final + fuzzySearch + equals + "Dark Magician";
        }

        private void DetermineSearchTypes(string searchCvs, string termCvs)
        {
            searchTerms = searchCvs.Split(',');
            string[] search = termCvs.Split(',');
            toSearch = new searchTerm[search.Length ];
            for(int index =0; index < search.Length-1;index++)
            {
                int searchNum = Int32.Parse(search[index]);
                switch (searchNum)
                {
                    case 1: // Attribute
                        toSearch[index] = searchTerm.attributeSearch;
                        break;
                    case 2: // cardSet
                        toSearch[index] = searchTerm.cardsetSearch;
                        break;
                    case 3: // formatSearch
                        toSearch[index] = searchTerm.formatSearch;
                        break;
                    case 4: // fuzzy search
                        toSearch[index] = searchTerm.fuzzySearch;
                        break;
                    case 5: // name search
                        toSearch[index] = searchTerm.nameSearch;
                        break;
                    case 6: // Stable Search
                        toSearch[index] = searchTerm.stableSearch;
                        break;
                    case 7: //type search
                        toSearch[index] = searchTerm.typeSearch;
                        break;
                    default:
                        toSearch[index] = searchTerm.fuzzySearch;
                        break;        
                }
            }
        }
    }
}
