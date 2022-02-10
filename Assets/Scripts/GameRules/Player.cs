public class Player
{
    public MarkType MarkTypeHolding { get; private set; }
    public string Name { get; }

    public Player(MarkType markTypeHolding, string name)
    {
        MarkTypeHolding = markTypeHolding;
        Name = name;
    }

    public void ChangeMarkType(MarkType newMark)
    {
        MarkTypeHolding = newMark;
    }
}