using UnityEngine;

public class CarController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        // Rotate the car around its up axis based on user input
        transform.Rotate(Vector3.up, rotationAmount);

        // Set animator parameter based on input to trigger the appropriate animation
        if (horizontalInput > 0)
        {
            animator.SetBool("TurnRight", true);
            animator.SetBool("TurnLeft", false);
        }
        else if (horizontalInput < 0)
        {
            animator.SetBool("TurnRight", false);
            animator.SetBool("TurnLeft", true);
        }
        else
        {
            animator.SetBool("TurnRight", false);
            animator.SetBool("TurnLeft", false);
        }
    }
}
