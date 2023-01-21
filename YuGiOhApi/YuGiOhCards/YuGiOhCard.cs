using System.Globalization;
using CardCore;
using Newtonsoft.Json.Linq;

namespace CardSearchApi.YuGiOhCards;

public class YuGiOhCard: CardBase
{
    private int cardAttack;
    private int cardDefense;
    private int cardLevel;
    
    private CardType cardType;
    private CardAttributes cardAttribute;
    private CardFrameType cardFrameType;
    private CardRace cardRace;

    
    public int GetAttack() => cardAttack;
    public int GetDefense() => cardDefense;
    
    public override ICardSet GetACardSet(string setName, string setCode)
    {
        return cardSets.FirstOrDefault(x => String.CompareOrdinal(x.GetSetCode(), setCode) == 0)!;
    }

    public override void CreateCardFromJson(JToken jsonObject)
    {
        cardId = (int)(jsonObject["id"] ?? cardId);
        cardName = (string)(jsonObject["name"]?? cardName)!;
        cardType = YuGiOhEnums.ConvertStringToCardTypes((string)jsonObject["type"]!);
        cardFrameType = YuGiOhEnums.ConvertStringToCardFrameTypes((string)jsonObject["frameType"]!);
        cardDescription = (string)jsonObject["desc"]!;
        cardAttack = (int)jsonObject["atk"]!;
        cardDefense = (int)jsonObject["def"]!;
        cardLevel = (int)jsonObject["level"]!;
        cardRace = YuGiOhEnums.ConvertStringToCardRace((string)jsonObject["race"]!);
        cardAttribute = YuGiOhEnums.ConvertStringToCardAttribute((string)jsonObject["attribute"]!);
        
        SetupCardSets((JArray)jsonObject["card_sets"]);
        SetupCardImages((JArray)jsonObject["card_images"]);
        SetupCardPrices((JArray)jsonObject["card_prices"]);
    }

    private void SetupCardPrices(JArray? jArray)
    {
        foreach (JToken token in jArray)
        {
            cardPrice = new YuGiOhPrice();
            double price = (double)token["amazon_price"]!;
            cardPrice.SetAmazonPrice(price.ToString(CultureInfo.CurrentCulture));
            price = (double)token["ebay_price"]!;
            cardPrice.SetEbayPrice(price.ToString(CultureInfo.CurrentCulture));
            price = (double)token["cardmarket_price"]!;
            cardPrice.SetMarketPrice(price.ToString(CultureInfo.CurrentCulture));
            price = (double)token["coolstuffinc_price"]!;
            cardPrice.SetCoolStuffPrice(price.ToString(CultureInfo.CurrentCulture));
            price = (double)token["tcgplayer_price"]!;
            cardPrice.SetTcgPlayerPrice(price.ToString(CultureInfo.CurrentCulture));
        }
    }

    private void SetupCardImages(JArray? jArray)
    {
        foreach (JToken token in jArray)
        {
            YuGiOhImages cardImage = new YuGiOhImages();
            cardImage.SetImageId((int)token["id"]!);
            cardImage.SetLargeImageUrl((string)token["image_url"]!);
            cardImage.SetSmallImageUrl((string)token["image_url_small"]!);
            cardImages.Add(cardImage);
        }
    }

    private void SetupCardSets(JArray jArray)
    {
        foreach (JToken token in jArray)
        {
            YuGiOhSets cardSet = new YuGiOhSets();
            cardSet.SetSetCode((string)token["set_code"]!);
            cardSet.SetSetName((string)token["set_name"]!);
            cardSet.SetSetPrice((string)token["set_price"]!);
            cardSet.SetSetRarity((string)token["set_rarity"]!);
            cardSet.SetSetRarityCode((string)token["set_rarity_code"]!);
            cardSets.Add(cardSet);
        }
    }

    public override void CreateCardFromJsonString(string jsonString)
    {
        JToken jsonToken = JToken.Parse(jsonString);
        if (jsonToken != null)
        {
            //TODO
        }
    }
}