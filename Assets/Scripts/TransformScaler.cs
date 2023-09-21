using UnityEngine;
using DG.Tweening;

public class TransformScaler : MonoBehaviour
{
    [SerializeField] private float targetScale = 1.15f;
    [SerializeField] private float scaleDuration = 0.75f;

    private Vector3 startScale;
    private void OnEnable()
    {
        transform.DOScale(targetScale, scaleDuration).SetLoops(-1, LoopType.Yoyo);
    }
    void Start()
    {
        startScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.DOComplete();
        transform.localScale = startScale;
    }
}
