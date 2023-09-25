using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private CinemachineVirtualCamera lookCam;

    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        followCam.enabled = true;
        lookCam.enabled = false;
    }

    private void Update()
    {
        /*
        if (Input.touchCount > 0)
        {
            bool touchingUI = false;

            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    // EventSystem.current.IsPointerOverGameObject ile dokunulan pozisyonun bir UI elemanı üzerinde olup olmadığını kontrol edin.
                    touchingUI = EventSystem.current.IsPointerOverGameObject(touch.fingerId);

                    if (!touchingUI)
                    {
                        followCam.enabled = false;
                        lookCam.transform.position = followCam.transform.position;
                        lookCam.transform.rotation = followCam.transform.rotation;
                        lookCam.enabled = true;
                    }
                    else
                    {
                        followCam.enabled = true;
                        lookCam.enabled = false;
                    }
                }
            }
        }
        else
        {
            followCam.enabled = true;
            lookCam.enabled = false;
        }*/
    }
}
