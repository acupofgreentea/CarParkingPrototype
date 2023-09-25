using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MainMenuCameraController : MonoBehaviour
{
    [Header("Required")]
    public Transform target;

    [Header("Config")]
    public float targetdistance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    public float ScrollSensativity = 4f;


    float x = 0.0f;
    float y = 0.0f;

    float targetx = 0.0f;
    float targety = 0.0f;
    float distance = 5f;

    private bool isActive;
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }

    void LateUpdate()
    {
        if(cinemachineVirtualCamera?.enabled == false)
        {
            targetx = 0f;
            targety = 0f;
            return;
        }
        
        if (target)
        {
            if (Input.touchCount == 1) // Tek dokunmatik parmak varsa
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    targetx += touch.deltaPosition.x * xSpeed * distance * 0.02f * (5 / (distance + 2));
                    targety -= touch.deltaPosition.y * ySpeed * 0.02f;
                }
            }

            targety = ClampAngle(targety, yMinLimit, yMaxLimit);

            x = Mathf.LerpAngle(x, targetx, 0.1f);
            y = Mathf.LerpAngle(y, targety, 1f);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            targetdistance = Mathf.Clamp(targetdistance - (Input.GetAxis("Mouse ScrollWheel") * ScrollSensativity), distanceMin, distanceMax);
            distance = Mathf.Lerp(distance, targetdistance, 0.1f); //Smooth

            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                targetdistance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;

            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
