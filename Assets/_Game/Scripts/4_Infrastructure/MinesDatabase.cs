using UnityEngine;

namespace MiningGame.Infrastructure
{
    [CreateAssetMenu(fileName = "MinesDatabase", menuName = "Configs/Mines/MinesDatabase", order = 1)]
    public class MinesDatabase : ScriptableObject, IMineGlobalConfig
    {
        [field: SerializeField] public int MaxNumberOfColumns { get; private set; }
        [field: SerializeField] public int MaxNumberOfRows { get; private set; }

      [field: SerializeField]  public MineLayoutConfig[] Configs { get; private set; }
    }

    public interface IMineGlobalConfig
    {
        int MaxNumberOfColumns { get; }
        int MaxNumberOfRows { get; }
    }
}