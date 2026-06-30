using System.Collections.Generic;
using UnityEngine;

namespace MiningGame.Infrastructure
{
    [System.Serializable, CreateAssetMenu(fileName = "MineLayoutConfig", menuName = "Configs/Mines/MineLayoutConfig", order = 2)]
    public class MineLayoutConfig : ScriptableObject
    {
        [field: SerializeField] public string LayoutID { get; private set; }
        [field: SerializeField] public List<Vector2Int> Cells { get; private set; } = new List<Vector2Int>();

        public void AddCell(Vector2Int newCell, IMineGlobalConfig config)
        {
            if (newCell.x < config.MaxNumberOfColumns && newCell.y < config.MaxNumberOfRows)
            {
                if (Cells == null) Cells = new List<Vector2Int>();
                Cells.Add(newCell);
            }
        }

        public void ClearCells() => Cells?.Clear();

        public bool GridFitLayoutConfig(IMineGlobalConfig config)
        {
            foreach (Vector2Int cell in Cells)
            {
                if (cell.x >= config.MaxNumberOfColumns || cell.y >= config.MaxNumberOfRows) return false;
            }
            return true;
        }

        public void FillAllCells(IMineGlobalConfig config)
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

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(MineLayoutConfig))]
    public class MineLayoutConfigEditor : UnityEditor.Editor
    {
        private MineLayoutConfig config;
        private IMineGlobalConfig globalConfig;

        private void OnEnable()
        {
            config = (MineLayoutConfig)target;
            globalConfig = UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/_Game/Containers/MinesDatabase.asset", typeof(IMineGlobalConfig)) as IMineGlobalConfig;
        }

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Fill All Cells"))
            {
                config.FillAllCells(globalConfig);
            }

            if (GUILayout.Button("Clear Cells"))
            {
                config.ClearCells();
            }

            GUILayout.Space(10);

            base.OnInspectorGUI();

        }
    }
#endif


}