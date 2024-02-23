using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Cube : MonoBehaviour
{
    [Header("Тип куба")] 
    [SerializeField] private SideType sideType;

    [Header("Направление куба")] 
    [SerializeField, Range(0, 4, order = 1)] private int directionMovement;

    private float _speed;
    private Action _onHitDestroy;
    private Action _onHitCorrectSaber;

    private void Start()
    {
        _speed = GameManager.Instance.GameData.CubSpeed;
        _onHitDestroy = GameManager.Instance.OnHitDestroy;
        _onHitCorrectSaber = GameManager.Instance.OnHitCorrectSaber;

        var rotation = transform.rotation;
        rotation = Quaternion.Euler(rotation.x, directionMovement, rotation.z);
        transform.rotation = rotation;
    }

    private void Update()
    {
        transform.Translate(Vector3.back * (_speed * Time.deltaTime));
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