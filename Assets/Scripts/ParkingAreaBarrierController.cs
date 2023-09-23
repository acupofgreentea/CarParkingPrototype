using DG.Tweening;
using UnityEngine;

public class ParkingAreaBarrierController : MonoBehaviour
{
    [SerializeField] private Transform barrier;
    [SerializeField] private Vector3 targetLocalRotation;

    [SerializeField] private float moveDuration = 0.5f;

    private Vector3 startLocalRotation;

    void Start()
    {
        startLocalRotation = barrier.localEulerAngles;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(!other.TryGetComponent(out PrometeoCarController player))
            return;
        barrier.DOLocalRotate(targetLocalRotation, moveDuration);
    }

    void OnTriggerExit(Collider other)
    {if(!other.TryGetComponent(out PrometeoCarController player))
            return;
        barrier.DOLocalRotate(startLocalRotation, moveDuration);
    }
}
