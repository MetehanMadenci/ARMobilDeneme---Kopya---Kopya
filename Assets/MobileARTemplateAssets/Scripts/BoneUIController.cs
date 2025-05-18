using UnityEngine;

public class BoneUIController : MonoBehaviour
{
    public CameraZoomer cameraZoomer;
    public void OnShowOnlySelected()
    {
        if (TouchableBone.currentlySelected != null)
        {
            TouchableBoneManager.Instance.ShowOnlySelected(TouchableBone.currentlySelected);
            cameraZoomer.ZoomTo(TouchableBone.currentlySelected.transform); // Zoom yap
        }
    }

    public void OnShowAll()
    {
        TouchableBoneManager.Instance.ShowAll();
    }
}
