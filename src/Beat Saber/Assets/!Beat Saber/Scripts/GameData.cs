using System;
using UnityEngine;

namespace Beat_Saber.Scripts
{
    [Serializable]
    public class GameData
    {
        [field: SerializeField, Header("Режим отладки")]
        public bool IsDebug { get; private set; }

        [field: SerializeField, Header("Скорость движения кубов")]
        public float CubSpeed { get; private set; }

        [field: SerializeField, Header("Скорость движения кубов")]
        public int HealthOnStart { get; private set; } = 3;
    }
}