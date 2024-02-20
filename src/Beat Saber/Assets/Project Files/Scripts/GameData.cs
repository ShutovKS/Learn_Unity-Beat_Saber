using System;
using UnityEngine;

[Serializable]
public partial class GameData
{
    [field: SerializeField] public float CubSpeed { get; private set; }
}