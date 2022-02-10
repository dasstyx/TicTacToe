public class ResolvePlayerFromResult
{
    private TurnWarden _turnWarden;
    
    public ResolvePlayerFromResult(TurnWarden turnWarden)
    {
        _turnWarden = turnWarden;
    }

    public Player ResultToPlayer(TurnResult result)
    {
        return _turnWarden.ActivePlayer;
    }
}