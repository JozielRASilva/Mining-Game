using UnityEngine;

public class OreResourceElement : MonoBehaviour, IResourceElement
{
    [field: SerializeField] public RectTransform Root { get; private set; }
    [field: SerializeField] public Vector2Int CurrentCenterPosition { get; set; }
    [field: SerializeField] public Vector2Int[] ElementShapeCells { get; private set; }

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
