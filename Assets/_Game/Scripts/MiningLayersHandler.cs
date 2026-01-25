using System.Collections.Generic;
using UnityEngine;

public class MiningLayersHandler : MonoBehaviour
{
    [SerializeField] public RectTransform ResourcesLayersHolder { get; private set; }
    [SerializeField] public RectTransform ObstructionLayerHolder { get; private set; }

    [field: SerializeField] public Dictionary<Vector2Int, IResourceElement> ResourceLayersElements { get; private set; } = new();
    [field: SerializeField] public Dictionary<Vector2Int, IObstructionElement> ObstructionLayersElements { get; private set; } = new();

    private GridLayoutGenerator gridLayoutGenerator;

    public void Initialize(GridLayoutGenerator gridLayoutGenerator)
    {
        this.gridLayoutGenerator = gridLayoutGenerator;
        foreach (Vector2Int position in gridLayoutGenerator.Cells.Keys)
        {
            if (!gridLayoutGenerator.IsCellActive(position)) continue;
            ResourceLayersElements.Add(position, null);
            ObstructionLayersElements.Add(position, null);
        }
    }

    public bool CanFitResourceElement(Vector2Int position, IResourceElement element)
    {
        for (int i = 0; i < element.ElementShapeCells.Length; i++)
        {
            Vector2Int cellOffset = element.ElementShapeCells[i];
            Vector2Int targetPosition = position + cellOffset;
            if (!ResourceLayersElements.ContainsKey(targetPosition)) return false;
            if (ResourceLayersElements[targetPosition] != null) return false;
        }
        return true;
    }

    public bool CanFitObstructionElement(Vector2Int position, IObstructionElement element)
    {
        if (!ObstructionLayersElements.ContainsKey(position)) return false;
        if (ObstructionLayersElements[position] != null) return false;
        return true;
    }

    public void PlaceResourceElement(Vector2Int position, IResourceElement element)
    {
        for (int i = 0; i < element.ElementShapeCells.Length; i++)
        {
            Vector2Int cellOffset = element.ElementShapeCells[i];
            Vector2Int targetPosition = position + cellOffset;
            ResourceLayersElements[targetPosition] = element;
        }
        element.SetPosition(gridLayoutGenerator.Cells[position].rectTransform);
        element.CurrentCenterPosition = position;
    }

    public void PlaceObstructionElement(Vector2Int position, IObstructionElement element)
    {
        ObstructionLayersElements[position] = element;
        element.SetPosition(gridLayoutGenerator.Cells[position].rectTransform);
        element.CurrentCenterPosition = position;
    }

    public void RemoveObstructionElement(Vector2Int position)
    {
        ObstructionLayersElements[position] = null;
    }

    public bool IsResourceUnobstructed(IResourceElement element)
    {
        for (int i = 0; i < element.ElementShapeCells.Length; i++)
        {
            Vector2Int cellOffset = element.ElementShapeCells[i];
            Vector2Int targetPosition = element.CurrentCenterPosition + cellOffset;
            if (ObstructionLayersElements[targetPosition] != null) return false;
        }
        return true;
    }
}
