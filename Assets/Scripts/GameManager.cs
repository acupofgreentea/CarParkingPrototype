using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public static event UnityAction<string> OnLevelCompleted;

    private void Start()
    {
        ParkingSlotManager.OnParkingSuccessful += HandleParkingSlotSuccessful;
    }
    private void HandleParkingSlotSuccessful()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);

        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        OnLevelCompleted?.Invoke(formattedTime);
    }

    private float currentTime = 0.0f;

    private void Update()
    {
        currentTime += Time.deltaTime;
    }
}
