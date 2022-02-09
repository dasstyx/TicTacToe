using UnityEngine;

public interface ITileViewGridFactory
{
    void Create(Transform root, int rows, int columns);
}