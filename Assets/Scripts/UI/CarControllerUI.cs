using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CarControllerUI : MonoBehaviour
{
    [SerializeField] private CarControllerButton gasButton;
    [SerializeField] private CarControllerButton brakeButton;
    [SerializeField] private CarControllerButton handBrakeButton;

    [SerializeField] private GameObject steeringWheel;

    [SerializeField] private TMP_Text carSpeedText;

    [SerializeField] private PrometeoCarController car;
    
    public static event UnityAction OnGasButtonPressed;
    public static event UnityAction OnGasButtonDePressed;
    
    public static event UnityAction OnBrakeButtonPressed;
    public static event UnityAction OnBrakeButtonDePressed;

    void Start()
    {
        gasButton.OnButtonPressed += HandleGasButtonPressed;
        gasButton.OnButtonDePressed += HandleGasButtonDePressed;
        brakeButton.OnButtonPressed += HandleBrakeButtonPressed;
        brakeButton.OnButtonDePressed += HandleBrakeButtonDePressed;

        GameManager.OnLevelCompleted += HandleLevelCompleted;
    }

    private void HandleLevelCompleted(string arg0, bool arg1)
    {
        carSpeedText.gameObject.SetActive(false);
        gasButton.gameObject.SetActive(false);
        brakeButton.gameObject.SetActive(false);
        steeringWheel.gameObject.SetActive(false);
    }

    void Update()
    {
        float speed = Mathf.Abs(car.carSpeed);
        carSpeedText.text = speed.ToString("0");
    }

    private void HandleBrakeButtonDePressed()
    {
        OnBrakeButtonDePressed?.Invoke();
    }

    private void HandleBrakeButtonPressed()
    {
        OnBrakeButtonPressed?.Invoke();
    }

    private void HandleGasButtonDePressed()
    {
        OnGasButtonDePressed?.Invoke();
    }

    private void HandleGasButtonPressed()
    {
        OnGasButtonPressed?.Invoke();
    }

    void OnDestroy()
    {
        GameManager.OnLevelCompleted -= HandleLevelCompleted;
    }
}
