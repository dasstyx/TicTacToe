namespace tictac.GameRules.GameTurnCheck
{
    public interface ITicTacTurnChecker
    {
        void DoMove(MarkType mark, int x, int y);
    }
}