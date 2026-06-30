using UnityEngine;

namespace MiningGame.Infrastructure
{
    [CreateAssetMenu(fileName = "MineElementsDatabase", menuName = "Configs/Elements/MineElementsDatabase", order = 0)]
    public class MineElementsDatabase : ScriptableObject
    {
        [field: SerializeField] public ObstructionElementConfig[] ObstructionElements { get; private set; }
        [field: SerializeField] public ResourceElementConfig[] ResourceElements { get; private set; }
    }
}