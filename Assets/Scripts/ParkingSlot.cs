using UnityEngine;

public class ParkingSlot : MonoBehaviour
{
    private MeshRenderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    public void EnableMeshRenderer(bool enable)
    {
        _renderer.enabled = enable;
    }

    public void HandleOnSelectedCurrent()
    {
        EnableMeshRenderer(true);
        GetComponent<Target>().IsActiveTarget = true;
    }
}
