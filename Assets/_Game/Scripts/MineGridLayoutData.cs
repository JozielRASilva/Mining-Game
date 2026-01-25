using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "MineGridLayoutData", menuName = "Configs/MineGridLayoutData", order = 1)]
public class MineGridLayoutData : ScriptableObject
{
    [field: SerializeField] public string LayoutID { get; private set; }
    [field: SerializeField] public List<Vector2Int> Cells { get; private set; } = new List<Vector2Int>();

    public void AddCell(Vector2Int newCell, MiningGridGlobalConfig config)
    {
        if (newCell.x < config.MaxNumberOfColumns && newCell.y < config.MaxNumberOfRows)
        {
            if (Cells == null) Cells = new List<Vector2Int>();
            Cells.Add(newCell);
        }
    }

    public void ClearCells() => Cells?.Clear();

    public bool GridFitLayoutConfig(MiningGridGlobalConfig config)
    {
        foreach (Vector2Int cell in Cells)
        {
            if (cell.x >= config.MaxNumberOfColumns || cell.y >= config.MaxNumberOfRows) return false;
        }
        return true;
    }

    public void FillAllCells(MiningGridGlobalConfig config)
    {
        ClearCells();
        for (int x = 0; x < config.MaxNumberOfColumns; x++)
        {
            for (int y = 0; y < config.MaxNumberOfRows; y++)
            {
                Cells.Add(new Vector2Int(x, y));
            }
        }
    }
}