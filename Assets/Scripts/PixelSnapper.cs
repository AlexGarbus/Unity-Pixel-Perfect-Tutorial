using UnityEngine;
using UnityEngine.U2D;

public class PixelSnapper : MonoBehaviour
{
    private PixelPerfectCamera pixelPerfectCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to pixel perfect camera
        pixelPerfectCamera = Camera.main.GetComponent<PixelPerfectCamera>();
    }

    // LateUpdate is called once per frame after all Update functions have been called
    void LateUpdate()
    {
        // Check whether transform has changed
        if (transform.hasChanged)
        {
            // Set target position
            Vector2 targetPosition;
            if (transform.parent != null)
                targetPosition = (Vector2)transform.parent.position + (Vector2)pixelPerfectCamera.RoundToPixel(transform.localPosition);
            else
                targetPosition = transform.position;

            // Snap to pixel grid
            transform.position = pixelPerfectCamera.RoundToPixel(targetPosition);
            transform.hasChanged = false;
        }
    }
}
