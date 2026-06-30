using UnityEngine;
using MiningGame.Domain;
using MiningGame.Infrastructure;

namespace MiningGame.Core
{
    public class GameplayCoordinator : MonoBehaviour
    {
        [field: SerializeField] public MineGame MineGame { get; set; }

        [field: SerializeField] public MineLayoutConfig SelectedMine { get; set; }

        public void Initialize()
        {
            MineGame = new MineGame(null);
        }
    }
}