using UnityEngine;

namespace Beat_Saber.Scripts
{
    public class Saber : MonoBehaviour
    {
        [field: SerializeField, Header("Тип кубов которые должны резаться")] 
        public SideType SideType { get; private set; }
    }
}