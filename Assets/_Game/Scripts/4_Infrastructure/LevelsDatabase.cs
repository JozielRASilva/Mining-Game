using UnityEngine;
namespace MiningGame.Infrastructure
{
    [CreateAssetMenu(fileName = "LevelsDatabase", menuName = "Configs/Levels/LevelsDatabase", order = 0)]
    public class LevelsDatabase : ScriptableObject
    {
        [field: SerializeField] public LevelConfig[] Levels { get; private set; }
    }
}