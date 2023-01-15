using System.Text.Json.Nodes;
using CardCore;

namespace CardSearchApi.YuGiOhCards;

public class YuGiOhCard: CardBase
{
    private CardTypes cardType;
    private int cardAttack;
    private int cardDefense;
    private int cardLevel;
    
    private  CardTypes cardRace;
    private CardAttributes cardAttribute;


    
    
    public override ICardSet GetACardSet(string setName, string setCode)
    {
        return cardSets.FirstOrDefault(x => String.CompareOrdinal(x.GetSetCode(), setCode) == 0)!;
    }

    public override void CreateCardFromJson(JsonObject jsonObject)
    {
       //TODO Bring through a JSON string or Object and create the card.
    }
}