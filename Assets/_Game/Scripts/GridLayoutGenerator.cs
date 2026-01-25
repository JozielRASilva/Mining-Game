using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridLayoutGenerator : MonoBehaviour
{
    [field: SerializeField] public MiningGridGlobalConfig SelectedGridConfig { get; private set; }

    [field: SerializeField] private GridLayoutGroup gridLayoutGroup;
    [field: SerializeField] private RectTransform holder;
    [field: SerializeField] private RectTransform cellTemplate;

    [field: SerializeField] public Dictionary<Vector2Int, (RectTransform rectTransform, bool isActive)> Cells { get; private set; } = new();

    public void Initialize(MineGridLayoutData gridData)
    {
        Cells.Keys.ToList().ForEach(cellKey => Cells[cellKey] = (Cells[cellKey].rectTransform, false));
        for (int i = 0; i < gridData.Cells.Count; i++)
        {
            Vector2Int cellPos = gridData.Cells[i];
            if (Cells.ContainsKey(cellPos)) Cells[cellPos] = (Cells[cellPos].rectTransform, true);
        }
    }

    public bool IsCellActive(Vector2Int cellPosition)
    {
        if (Cells.ContainsKey(cellPosition)) return Cells[cellPosition].isActive;
        return false;
    }

#if UNITY_EDITOR
    public void GenerateGrid()
    {
        gridLayoutGroup.constraintCount = SelectedGridConfig.MaxNumberOfColumns;
        Cells.Clear();

        int totalCells = SelectedGridConfig.MaxNumberOfColumns * SelectedGridConfig.MaxNumberOfRows;
        int currentCells = holder.childCount;

        for (int i = currentCells; i < totalCells; i++)
        {
            RectTransform newCell = Instantiate(cellTemplate, holder);
            newCell.gameObject.SetActive(true);
            newCell.name = $"Cell_{i}";
        }

        for (int i = currentCells - 1; i >= totalCells; i--)
        {
            Transform cellToRemove = holder.GetChild(i);
            DestroyImmediate(cellToRemove.gameObject);
        }

        for (int i = 0; i < holder.childCount; i++)
        {
            RectTransform cell = holder.GetChild(i).GetComponent<RectTransform>();
            int row = i / SelectedGridConfig.MaxNumberOfColumns;
            int column = i % SelectedGridConfig.MaxNumberOfColumns;
            cell.name = $"Cell_{column}_{row}";
            Cells[new Vector2Int(column, row)] = (cell, false);
        }
    }
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(GridLayoutGenerator))]
public class GridGeneratorEditor : Editor
{
    private GridLayoutGenerator gridGenerator;

    private void OnEnable()
    {
        gridGenerator = (GridLayoutGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Label("Editor Tools", EditorStyles.boldLabel);
        GUILayout.Space(10);
        if (GUILayout.Button("Generate Grid"))
        {
            gridGenerator.GenerateGrid();
        }
    }
}
#endif