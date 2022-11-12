using System.Text.Json.Nodes;

namespace CardSearchApi.BaseCardClasses;

public class YuGiOhCardCreator : CardCreatorBase
{
    public override TradingCardBase CardCreator(string item)
    {
        try
        {
            throw new ArithmeticException("testing this");
        }
        catch (Exception e)
        {
            Debug.DebugLog.WriteDebugLog("There was an issue using string Creator in YuGiOhCreator: "+e);
            return null;
        }
        
    }

    public override TradingCardBase CardCreator(JsonObject item)
    {
        try
        {
            throw new ArithmeticException("testing this");
        }
        catch (Exception e)
        {
            Debug.DebugLog.WriteDebugLog("There was an issue using JsonObject Creator in YuGiOhCreator: "+e);
            return null;
        }
    }

    public override TradingCardBase CardCreator(HttpContent item)
    {
        try
        {
            throw new ArithmeticException("testing this");
        }
        catch (Exception e)
        {
            Debug.DebugLog.WriteDebugLog("There was an issue using HttpContent Creator in YuGiOhCreator: "+e);
            return null;
        }
    }
}