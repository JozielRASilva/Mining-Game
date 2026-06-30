using UnityEngine;
using MiningGame.Contracts.MiningContracts;

namespace MiningGame.Infrastructure
{
    [CreateAssetMenu(fileName = "ResourceElementConfig", menuName = "Configs/Elements/Resource Element", order = 2)]
    public class ResourceElementConfig : ScriptableObject, IMineElement
    {
        [field: SerializeField] public int Value { get; set; }
        [field: SerializeField] public Vector2Int[] Size { get; set; }
    }
}