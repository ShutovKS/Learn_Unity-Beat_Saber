using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Cube : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SideType sideType;

    private Action _onHitDestroy;
    private Action _onHitCorrectSaber;

    private void Start()
    {
        _onHitDestroy = GameManager.Instance.OnHitDestroy;
        _onHitCorrectSaber = GameManager.Instance.OnHitCorrectSaber;
    }

    private void Update()
    {
        transform.Translate(Vector3.back * (speed * Time.deltaTime));
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