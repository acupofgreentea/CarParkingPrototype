using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarControllerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isActive;

    public event UnityAction OnButtonPressing;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isActive = true;
        button.interactable = false;
    }

    void Update()
    {
        if(!isActive)
            return;
        OnButtonPressing?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isActive = false;
        button.interactable = true;
    }
}
