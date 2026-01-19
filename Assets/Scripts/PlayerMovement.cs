using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;  
    
    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate move direction (transform.forward * vertical)
        moveDirection = transform.forward * vertical;

        // Set rb.velocity - keep the existing Y velocity for gravity!
        rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, rb.linearVelocity.y, moveDirection.z * moveSpeed);
    }

    void Update()
    {
        // ONLY rotation here - nothing else!
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
    }
}
