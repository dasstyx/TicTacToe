namespace tictac.Tiles
{
    public interface ITile
    {
        int X { get; }
        int Y { get; }
        bool ApplyTile();
    }
}