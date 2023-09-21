using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CarControllerButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isActive;

    public event UnityAction OnButtonPressing;
    public void OnPointerDown(PointerEventData eventData)
    {
        isActive = true;
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
    }
}
