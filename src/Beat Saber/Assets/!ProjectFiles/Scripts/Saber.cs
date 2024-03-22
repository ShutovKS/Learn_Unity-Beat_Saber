using UnityEngine;

public class Saber : MonoBehaviour
{
    [Header("Тип кубов которые должны резаться")]
    [field: SerializeField] public SideType SideType { get; private set; }
}