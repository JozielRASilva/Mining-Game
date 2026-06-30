using UnityEngine;

namespace MiningGame.Infrastructure
{
    [CreateAssetMenu(fileName = "ResourceElementConfig", menuName = "Configs/Elements/Resource Element", order = 2)]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public string LevelName { get; private set; }
        [field: SerializeField] public MineLayoutConfig MineLayout { get; private set; }
        [field: SerializeField] public ObstructionElementConfig[] ObstructionElements { get; private set; }
        [field: SerializeField] public ExpectedResources[] Resources { get; private set; }

        public struct ExpectedResources
        {
            public ResourceElementConfig ResourceConfig { get; private set; }
            public int ExpectedAmount { get; private set; }
        }
    }
}
