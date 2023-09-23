using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] startPositions;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public static event UnityAction<string, bool> OnLevelCompleted;

    private void Start()
    {
        var startPos = startPositions[Random.Range(0, startPositions.Length)];
        player.transform.position = startPos.position;
        
        ParkingSlotManager.OnParkingSuccessful += HandleParkingSlotSuccessful;
        PlayerHealth.OnPlayerDie += HandleOnPlayerDie;
    }
    private void HandleParkingSlotSuccessful()
    {
        OnLevelCompleted?.Invoke(GetTime(), true);
    }

    private string GetTime()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);

        string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        return formattedTime;
    }

    private void HandleOnPlayerDie()
    {
        OnLevelCompleted?.Invoke(GetTime(), false);
    }

    private float currentTime = 0.0f;

    private void Update()
    {
        currentTime += Time.deltaTime;
    }
}
