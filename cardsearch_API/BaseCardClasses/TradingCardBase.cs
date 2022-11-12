namespace CardSearchApi.BaseCardClasses;

public abstract class TradingCardBase
{
    protected string nameOfCard;
    protected string descriptionOfCard;
    
    public string Name => nameOfCard;
    public string Description => descriptionOfCard;
}