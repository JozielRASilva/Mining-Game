using System;
using UnityEngine;
using System.Collections.Generic;
using MiningGame.Contracts.MiningContracts;
using MiningGame.Infrastructure;

namespace MiningGame.Domain
{
    public class MineGame
    {
        private List<Vector2Int> BoardCells => MineLayoutConfig.Cells;
        private MineLayoutConfig MineLayoutConfig;

        public Dictionary<int, ObstructionElement> ObstructionElements = new();
        public Dictionary<int, ResourceElement> ResourceElements = new();

        public Dictionary<Vector3Int, MineCellData> ObstructionLayer = new();
        public Dictionary<Vector3Int, MineCellData> ResourcesLayer = new();

        public MineGame(LevelConfig levelConfig)
        {
            MineLayoutConfig = levelConfig.MineLayout;

            BuildObstructionLayer(levelConfig.ObstructionElements);
            BuildResourcesLayer(levelConfig.Resources);
        }

        private void BuildObstructionLayer(ObstructionElementConfig[] obstructionElements)
        {
            
        }

        private void BuildResourcesLayer(LevelConfig.ExpectedResources[] resources)
        {

        }
    }

    public struct MineCellData
    {
        public bool IsRoot;
        public int elementGUID;
    }

    public struct ObstructionElement : IMineElement
    {
        public bool isMined;
        public int durability;
        public Vector2Int[] Size { get; set; }
    }

    public struct ResourceElement : IMineElement
    {
        public bool IsRevealed;
        public Vector2Int[] Size { get; set; }
    }
}