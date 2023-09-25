using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarControllerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction OnButtonPressed;
    public event UnityAction OnButtonDePressed;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>(); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        button.interactable = false;
        OnButtonPressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonDePressed?.Invoke();
        button.interactable = true;
    }
}
