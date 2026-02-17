using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiningGridGlobalConfig", menuName = "Configs/MiningGridGlobalConfig", order = 10)]
public class MiningGridGlobalConfig : ScriptableObject
{
    [field: SerializeField] public int MaxNumberOfColumns { get; private set; }
    [field: SerializeField] public int MaxNumberOfRows { get; private set; }
}