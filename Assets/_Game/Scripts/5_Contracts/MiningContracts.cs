using UnityEngine;

namespace MiningGame.Contracts.MiningContracts
{
    // It will define the interfaces and data transfer objects (DTOs) that will be used across different layers of the application.

    public interface IMineElement
    {
        Vector2Int[] Size { get; }
    }
}
