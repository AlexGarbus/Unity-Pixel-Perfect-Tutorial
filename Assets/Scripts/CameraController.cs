using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [Tooltip("The target object that this camera should follow.")]
    [SerializeField] private Transform followTarget;
    [Tooltip("The time it takes for this camera to smoothly move to its target.")]
    [SerializeField] private float smoothTime;

    private Vector2 dampVelocity;

    // Update is called once per frame
    void Update()
    {
        // Get current position
        Vector3 currentPosition = transform.position;

        // Check whether current x and y positions are equal to target x and y positions
        if ((Vector2)currentPosition != (Vector2)followTarget.position)
        {
            // Smoothly move to target
            Vector2 dampPosition = Vector2.SmoothDamp(transform.position, followTarget.position, ref dampVelocity, smoothTime);
            transform.position = new Vector3(dampPosition.x, dampPosition.y, currentPosition.z);
        }
    }
}
