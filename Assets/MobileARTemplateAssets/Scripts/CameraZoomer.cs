using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    public float zoomSpeed = 5f;
    public float zoomDistance = 0.5f;

    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    public void ZoomTo(Transform target)
    {
        Vector3 direction = (cameraTransform.position - target.position).normalized;
        Vector3 targetPosition = target.position + direction * zoomDistance;

        StopAllCoroutines();
        StartCoroutine(SmoothZoom(targetPosition));
    }

    private System.Collections.IEnumerator SmoothZoom(Vector3 targetPosition)
    {
        float elapsed = 0f;
        Vector3 startPos = cameraTransform.position;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * zoomSpeed;
            cameraTransform.position = Vector3.Lerp(startPos, targetPosition, elapsed);
            yield return null;
        }
    }
}
