using System;
using UnityEngine;

[Serializable]
public class GameData
{
    [field: SerializeField] public bool IsDebug { get; private set; }
    
    [Header("Скорость движения кубов")]
    [field: SerializeField] public float CubSpeed { get; private set; }

    [Header("Скорость движения кубов")]
    [field: SerializeField] public int HealthOnStart { get; private set; } = 3;

}