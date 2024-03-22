using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Cube : MonoBehaviour
{
    [Header("Тип куба")] 
    [SerializeField] private SideType sideType;

    private float _speed;
    private Action _onHitDestroy;
    private Action _onHitCorrectSaber;

    private void Start()
    {
        _speed = GameManager.Instance.GameData.CubSpeed;
        _onHitDestroy = GameManager.Instance.OnHitDestroy;
        _onHitCorrectSaber = GameManager.Instance.OnHitCorrectSaber;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime), Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Saber>(out var saber))
        {
            if (saber.SideType == sideType)
            {
                Destroy(_onHitCorrectSaber);
                return;
            }

            Destroy(_onHitDestroy);
        }
        else if (other.TryGetComponent<Destroyer>(out _))
        {
            Destroy(_onHitDestroy);
        }
    }

    private void Destroy(Action action)
    {
        action?.Invoke();
        Object.Destroy(gameObject);
    }
}