
namespace cardsearch_API
{
    public class ConverterForEnums
    {
        public searchTerm ConvertStringToSearchTerm(string search)
        {
            searchTerm searchTerm;

            switch (search.ToLower())
            {
                case "fname":
                case "fuzzy name":
                case "fuzzy search":
                case "fsearch":
                    searchTerm = searchTerm.fuzzySearch;
                    break;
                case "name search":
                case "namesearch":
                case "cardname":
                case "card name":
                case "card":
                    searchTerm = searchTerm.nameSearch;
                    break;
                case "type search":
                case "typesearch":
                case "type":
                    searchTerm = searchTerm.typeSearch;
                    break;
                case "attribute search":
                case "attributesearch":
                    searchTerm = searchTerm.attributeSearch;
                    break;
                case "card set search":
                case "cardsetsearch":
                case "cardset search":
                case "card setsearch":
                case "card set":
                case "cardset":
                    searchTerm = searchTerm.cardsetSearch;
                    break;
                case "format search":
                case "format":
                case "game format":
                case "gameformat":
                    searchTerm = searchTerm.formatSearch;
                    break;
                case "stablesearch":
                case "stable search":
                    searchTerm = searchTerm.stableSearch;
                    break;
                case "archetype":
                    case "archetype search":
                        case "arche type search":
                    searchTerm = searchTerm.arhcetypeSearch;
                    break;
                default:
                    searchTerm = searchTerm.fuzzySearch;
                    break;
            }

            return searchTerm;
        }

        public string ConvertingSearchTermToString(searchTerm term)
        {
            switch (term)
            {
                case searchTerm.fuzzySearch:
                    return "fname";
                case searchTerm.attributeSearch:
                    return "attribute";
                case searchTerm.nameSearch:
                    return "name";
                case searchTerm.typeSearch:
                    return "type";
                case searchTerm.cardsetSearch:
                    return "cardset";
                case searchTerm.formatSearch:
                    return "format";
                case searchTerm.stableSearch:
                    return "stable";
                case searchTerm.arhcetypeSearch:
                    return "archetype";
                default:
                    return "fname";
            }

            
        }
    }    
}
