using UnityEngine;

namespace tictac.UI
{
    public interface IMarkViewFactory
    {
        GameObject Create(MarkType type, Vector2 position);
    }
}