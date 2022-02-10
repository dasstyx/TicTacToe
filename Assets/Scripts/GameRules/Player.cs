namespace tictac.GameRules
{
    public class Player
    {
        public Player(MarkType markTypeHolding, string name)
        {
            MarkTypeHolding = markTypeHolding;
            Name = name;
        }

        public MarkType MarkTypeHolding { get; private set; }
        public string Name { get; }

        public void ChangeMarkType(MarkType newMark)
        {
            MarkTypeHolding = newMark;
        }
    }
}