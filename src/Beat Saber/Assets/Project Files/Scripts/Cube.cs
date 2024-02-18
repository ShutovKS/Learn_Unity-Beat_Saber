using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SideType sideType;

    private Action _onHitDestroy;
    private Action _onHitCorrectSaber;

    private void Start()
    {
        var rotationZ = 90 * Random.Range(0, 4);

        transform.Rotate(0, 0, rotationZ);
    }

    public void SetUpActions(Action onHitDestroy, Action onHitCorrectSaber)
    {
        _onHitDestroy = onHitDestroy;
        _onHitCorrectSaber = onHitCorrectSaber;
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
                _onHitCorrectSaber?.Invoke();
                Destroy(gameObject);
            }
            else
            {
                _onHitDestroy?.Invoke();
                Destroy(gameObject);
            }
        }
        else if (other.TryGetComponent<Destroyer>(out _))
        {
            _onHitDestroy?.Invoke();
            Destroy(gameObject);
        }
    }
}