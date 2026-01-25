using UnityEngine;

public class StoneObstructionElement : MonoBehaviour, IObstructionElement
{
    [field: SerializeField] public RectTransform Root { get; private set; }
    public Vector2Int CurrentCenterPosition { get; set; }

    public void Initialize()
    {
        //TODO: Implement Initialize logic
    }

    public void Remove()
    {
        //TODO: Implement Remove logic
    }

    public void SetPosition(RectTransform targetTransform)
    {
        Root.position = targetTransform.position; //TODO: How to deal with local vs world position?
    }
}
