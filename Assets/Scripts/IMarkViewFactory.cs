using UnityEngine;

public interface IMarkViewFactory
{
    GameObject Create(MarkType type, Vector2 position);
}