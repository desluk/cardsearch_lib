using System;
using System.Linq;
using System.Text.Json.Nodes;
using CardCore;

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

    public override void CreateCardFromJson(JsonObject jsonObject)
    {
        var test = jsonObject["id"];
        var ten = jsonObject["name"];
    }
}