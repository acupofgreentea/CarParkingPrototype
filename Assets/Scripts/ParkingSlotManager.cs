using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParkingSlotManager : MonoBehaviour
{
    [SerializeField] private List<ParkingSlot> parkingSlots;

    [SerializeField] private List<Transform> parkedCars;
    [SerializeField] private Transform playerCar;

    [SerializeField] private float distanceTreshold = 1;
    [SerializeField] private float dotTreshold = 0.95f;
    private ParkingSlot currentParkingSlot;

    public static event UnityAction OnParkingSuccessful;

    private void Start()
    {
        for (int i = 0; i < parkingSlots.Count; i++)
        {
            parkingSlots[i].GetComponent<MeshRenderer>().enabled = false;
        }

        for (int i = 0; i < parkedCars.Count; i++)
        {
            var slot = parkingSlots[Random.Range(0, parkingSlots.Count)];
            parkingSlots.Remove(slot);

            parkedCars[i].transform.position = slot.transform.position;    
            parkedCars[i].transform.localEulerAngles = slot.transform.localEulerAngles;    
        }

        currentParkingSlot = parkingSlots[Random.Range(0, parkingSlots.Count)];

        currentParkingSlot.GetComponent<MeshRenderer>().enabled = true;
    }

    private void Update()
    {
        if(Vector3.Distance(playerCar.position, currentParkingSlot.transform.position) < distanceTreshold)
        {
            Vector3 carForward = playerCar.forward;
            Vector3 distanceForward = currentParkingSlot.transform.position - playerCar.position;
            distanceForward = distanceForward.normalized;

            if(Mathf.Abs(Vector3.Dot(carForward, distanceForward)) > dotTreshold)
            {
                OnParkingSuccessful?.Invoke();
                Debug.LogError("parking is successful");
            }
        }
    }
}
