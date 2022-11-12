using System.Text.Json.Nodes;

namespace CardSearchApi.BaseCardClasses;

public abstract class CardCreatorBase
{
    public abstract TradingCardBase CardCreator(string item);

    public abstract TradingCardBase CardCreator(JsonObject item);

    public abstract TradingCardBase CardCreator(HttpContent item);
}