namespace CardSearchApi.YuGiOhCards;

public static class YuGiOhEnums
{
    #region Enums
    public enum CardTypes
    {
        Aqua,
        Beast,
        BeastWarrior,
        Cyberse,
        Dinosaur,
        DivineBeast,
        Dragon,
        Fairy,
        Fiend,
        Fish,
        Insect,
        Machine,
        Plant,
        Psychic,
        Pyro,
        Reptile,
        Rock,
        SeaSerpent,
        SpellCaster,
        Thunder,
        Warrior,
        WingedBeast,
        Wyrm,
        Zombie
    }
    
    public enum CardAttributes
    {
        Dark,
        Divine,
        Earth,
        Wind,
        Fire,
        Light,
        Water
    }
    
    public enum SearchTerm
    {
        FuzzySearch,
        NameSearch,
        TypeSearch,
        AttributeSearch,
        CardsetSearch,
        FormatSearch,
        StableSearch,
        ArhcetypeSearch
    }
    #endregion
    
    #region Enums for Search Terms

        public static SearchTerm ConvertStringToSearchTerm(string? search)
        {
            SearchTerm searchTerm;

            switch (search.ToLower())
            {
                case "fname":
                case "fuzzy name":
                case "fuzzy search":
                case "fsearch":
                    searchTerm = SearchTerm.FuzzySearch;
                    break;
                case "name search":
                case "namesearch":
                case "cardname":
                case "card name":
                case "card":
                case "name":
                    searchTerm = SearchTerm.NameSearch;
                    break;
                case "type search":
                case "typesearch":
                case "type":
                    searchTerm = SearchTerm.TypeSearch;
                    break;
                case "attribute search":
                case "attributesearch":
                    searchTerm = SearchTerm.AttributeSearch;
                    break;
                case "card set search":
                case "cardsetsearch":
                case "cardset search":
                case "card setsearch":
                case "card set":
                case "cardset":
                    searchTerm = SearchTerm.CardsetSearch;
                    break;
                case "format search":
                case "format":
                case "game format":
                case "gameformat":
                    searchTerm = SearchTerm.FormatSearch;
                    break;
                case "stablesearch":
                case "stable search":
                    searchTerm = SearchTerm.StableSearch;
                    break;
                case "archetype":
                case "archetype search":
                case "arche type search":
                    searchTerm = SearchTerm.ArhcetypeSearch;
                    break;
                default:
                    searchTerm = SearchTerm.FuzzySearch;
                    break;
            }

            return searchTerm;
        }

        public static string ConvertingSearchTermToString(SearchTerm term)
        {
            switch (term)
            {
                case SearchTerm.FuzzySearch:
                    return "fname";
                case SearchTerm.AttributeSearch:
                    return "attribute";
                case SearchTerm.NameSearch:
                    return "name";
                case SearchTerm.TypeSearch:
                    return "type";
                case SearchTerm.CardsetSearch:
                    return "cardset";
                case SearchTerm.FormatSearch:
                    return "format";
                case SearchTerm.StableSearch:
                    return "stable";
                case SearchTerm.ArhcetypeSearch:
                    return "archetype";
                default:
                    return "fname";
            }
        }

        #endregion

        #region Enum Conversion for Card Attributes

        public static CardAttributes ConvertStringToCardAttribute(string attribute)
        {
            switch (attribute.ToLower())
            {
                case "dark":
                    return CardAttributes.Dark;
                case "divine":
                    return CardAttributes.Divine;
                case "earth":
                    return CardAttributes.Earth;
                case "wind":
                    return CardAttributes.Wind;
                case "fire":
                    return CardAttributes.Fire;
                case "light":
                    return CardAttributes.Light;
                case "water":
                    return CardAttributes.Water;
                default:
                    return CardAttributes.Dark;
            }
        }

        public static string ConvertCardAttributeToString(CardAttributes attributes)
        {
            switch (attributes)
            {
                case CardAttributes.Dark:
                    return "Dark";
                case CardAttributes.Divine:
                    return "Divine";
                case CardAttributes.Earth:
                    return "Earth";
                case CardAttributes.Wind:
                    return "Wind";
                case CardAttributes.Fire:
                    return "Fire";
                case CardAttributes.Light:
                    return "light";
                case CardAttributes.Water:
                    return "water";
                default:
                    return "Dark";
                    
            }
        }

        #endregion

        #region Enum Conversion for Card Types

        public static CardTypes ConvertStringToCardTypes(string types)
        {
            switch (types.ToLower())
            {
                case "aqua":
                    return CardTypes.Aqua;
                case "beast":
                    return CardTypes.Beast;
                case "beastwarrior":
                case "beast-warrior":
                case "beast warrior":
                    return CardTypes.BeastWarrior;
                case "cyberse":
                    return CardTypes.Cyberse;
                case "dinosaur":
                case "dino":
                    return CardTypes.Dinosaur;
                case "divine-beast":
                case "divine beast":
                case "divinebeast":
                    return CardTypes.DivineBeast;
                case "dragon":
                    return CardTypes.Dragon;
                case "fairy":
                    return CardTypes.Fairy;
                case "fiend":
                case "demon":
                    return CardTypes.Fiend;
                case "fish":
                    return CardTypes.Fish;
                case "insect":
                    return CardTypes.Insect;
                case "machine":
                    return CardTypes.Machine;
                case "plant":
                    return CardTypes.Plant;
                case "psychic":
                    return CardTypes.Psychic;
                case "pyro":
                    return CardTypes.Pyro;
                case "reptile":
                    return CardTypes.Reptile;
                case "rock":
                    return CardTypes.Rock;
                case "sea serpent":
                case "seaserpent":
                case "sea serpant":
                case "seaserpant":
                    return CardTypes.SeaSerpent;
                case "spellcaster":
                case "spell caster":
                    return CardTypes.SpellCaster;
                case "thunder":
                    return CardTypes.Thunder;
                case "warrior":
                    return CardTypes.Warrior;
                case "winged-beast":
                case "wingedbeast":
                case "winged beast":
                    return CardTypes.WingedBeast;
                case "wyrm":
                    return CardTypes.Wyrm;
                case "zombie":
                    return CardTypes.Zombie;
                default:
                    return CardTypes.SpellCaster;
            }
        }

        public static string ConvertCardTypeToString(CardTypes types)
        {
            switch (types)
            {
                case CardTypes.Aqua:
                    return "Aqua";
                case CardTypes.Beast:
                    return "Beast";
                case CardTypes.BeastWarrior:
                    return "Beast-Warrior";
                case CardTypes.Cyberse:
                    return "Cyberse";
                case CardTypes.Dinosaur:
                    return "Dinosaur";
                case CardTypes.DivineBeast:
                    return "Divine-Beast";
                case CardTypes.Dragon:
                    return "Dragon";
                case CardTypes.Fairy:
                    return "Fairy";
                case CardTypes.Fiend:
                    return "Fiend";
                case CardTypes.Fish:
                    return "Fish";
                case CardTypes.Insect:
                    return "Insect";
                case CardTypes.Machine:
                    return "Machine";
                case CardTypes.Plant:
                    return "Plant";
                case CardTypes.Psychic:
                    return "Psychic";
                case CardTypes.Pyro:
                    return "Pyro";
                case CardTypes.Reptile:
                    return "Reptile";
                case CardTypes.SeaSerpent:
                    return "Sea Serpent";
                case CardTypes.SpellCaster:
                    return "Spellcaster";
                case CardTypes.Thunder:
                    return "Thunder";
                case CardTypes.Warrior:
                    return "Warrior";
                case CardTypes.WingedBeast:
                    return "Winged-Beast";
                case CardTypes.Wyrm:
                    return "Wyrm";
                case CardTypes.Zombie:
                    return "Zombie";
                default:
                    return "Spellcaster";
            }
        }
        
        #endregion
}