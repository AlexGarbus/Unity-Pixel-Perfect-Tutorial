using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("The velocity with which the player moves.")]
    [SerializeField] private float moveVelocity;

    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to Rigidbody2D
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input vector
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Set velocity
        rigidbody2d.velocity = input * moveVelocity * Time.deltaTime;
    }
}
