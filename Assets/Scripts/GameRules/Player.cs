public class Player
{
    public MarkType MarkTypeHolding { get; private set; }
    public string _name { get; private set; }

    public Player(MarkType markTypeHolding, string name)
    {
        MarkTypeHolding = markTypeHolding;
        _name = name;
    }

    public void ChangeMarkType(MarkType newMark)
    {
        MarkTypeHolding = newMark;
    }
}