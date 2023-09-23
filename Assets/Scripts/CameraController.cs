using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCam;

    void Start()
    {
        followCam.enabled = true;
    }

    private void ChangeCameraState(bool isFollowState)
    {
        if(isFollowState)
        {
            followCam.enabled = true;
        }
        else
        {
            followCam.enabled = false;
        }
    }
}
