using UnityEngine;

public interface IResourceElement
{
    RectTransform Root { get; }
    Vector2Int CurrentCenterPosition { get; set; }
    Vector2Int[] ElementShapeCells { get; }

    public void SetPosition(RectTransform targetTransform);
    void Initialize();
    void Remove();
}