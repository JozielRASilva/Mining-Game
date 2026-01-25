using UnityEngine;

public interface IObstructionElement
{
    RectTransform Root { get; }
    Vector2Int CurrentCenterPosition { get; set; }

    void SetPosition(RectTransform targetTransform);
    void Initialize();
    void Remove();
}