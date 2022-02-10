using tictac.GameRules;
using tictac.GameRules.GameTurnCheck;

namespace tictac
{
    public class ResolvePlayerFromResult
    {
        private readonly TurnWarden _turnWarden;

        public ResolvePlayerFromResult(TurnWarden turnWarden)
        {
            _turnWarden = turnWarden;
        }

        public Player ResultToPlayer(TurnResult result)
        {
            return _turnWarden.ActivePlayer;
        }
    }
}