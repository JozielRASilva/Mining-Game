using UnityEngine;
using MiningGame.Contracts.MiningContracts;

namespace MiningGame.Infrastructure
{
    [CreateAssetMenu(fileName = "ObstructionElementConfig", menuName = "Configs/Elements/Obstruction Element", order = 1)]
    public class ObstructionElementConfig : ScriptableObject, IMineElement
    {
        [field: SerializeField] public int Durability { get; set; }
        [field: SerializeField] public Vector2Int[] Size { get; set; }
    }
}