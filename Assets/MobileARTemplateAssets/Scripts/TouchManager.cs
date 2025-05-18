using UnityEngine;

public class TouchManager : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                TouchableBone touchedBone = hit.collider.GetComponent<TouchableBone>();
                if (touchedBone != null)
                {
                    touchedBone.OnTouched();
                }
            }
        }
    }
}
