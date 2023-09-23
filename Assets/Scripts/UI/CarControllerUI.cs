using UnityEngine;
using UnityEngine.Events;

public class CarControllerUI : MonoBehaviour
{
    [SerializeField] private CarControllerButton gasButton;
    [SerializeField] private CarControllerButton brakeButton;
    [SerializeField] private CarControllerButton handBrakeButton;
    
    public static event UnityAction GasButtonPressing;
    public static event UnityAction BrakeButtonPressing;
    public static event UnityAction HandBrakeButtonPressing;

    void Start()
    {
        gasButton.OnButtonPressing += HandleGasButtonActive;
        brakeButton.OnButtonPressing += HandleBrakeButtonActive;
        handBrakeButton.OnButtonPressing += HandleHandBrakeButtonActive;
    }

    private void HandleHandBrakeButtonActive()
    {
        HandBrakeButtonPressing?.Invoke();
    }

    private void HandleBrakeButtonActive()
    {
        BrakeButtonPressing?.Invoke();
    }

    private void HandleGasButtonActive()
    {        
        GasButtonPressing?.Invoke();
    }
}
