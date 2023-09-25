using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParkingSlotManager : MonoBehaviour
{
    [SerializeField] private List<ParkingSlot> parkingSlots;

    [SerializeField] private List<Transform> parkedCars;
    [SerializeField] private PrometeoCarController playerCar;

    [SerializeField] private float distanceTreshold = 1;
    [SerializeField] private float dotTreshold = 0.95f;
    private ParkingSlot currentParkingSlot;

    public static event UnityAction OnParkingSuccessful;

    private void Start()
    {
        foreach (ParkingSlot slot in parkingSlots)
        {
            slot.EnableMeshRenderer(false);
        }

        for (int i = 0; i < parkedCars.Count; i++)
        {
            var slot = parkingSlots[Random.Range(0, parkingSlots.Count)];
            parkingSlots.Remove(slot);

            Vector3 carPos = slot.transform.position;
            carPos.y += 0.3f;
            parkedCars[i].transform.position = carPos;    
            parkedCars[i].transform.localEulerAngles = slot.transform.localEulerAngles;    
        }

        currentParkingSlot = parkingSlots[Random.Range(0, parkingSlots.Count)];

        currentParkingSlot.HandleOnSelectedCurrent();
    }

    private bool isParkingCompleted = false;
    [SerializeField] private float velocityTreshold = 30f;

    private void Update()
    {
        if(isParkingCompleted)
            return;

        if(playerCar.CarSpeed >= velocityTreshold)
            return;
        
        if(Vector3.Distance(playerCar.transform.position, currentParkingSlot.transform.position) < distanceTreshold)
        {
            Vector3 carForward = playerCar.transform.forward;
            Vector3 distanceForward = currentParkingSlot.transform.position - playerCar.transform.position;
            distanceForward = distanceForward.normalized;

            if(Mathf.Abs(Vector3.Dot(carForward, distanceForward)) > dotTreshold)
            {
                OnParkingSuccessful?.Invoke();
                isParkingCompleted = true;
                Debug.LogError("parking is successful");
            }
        }
    }
}
