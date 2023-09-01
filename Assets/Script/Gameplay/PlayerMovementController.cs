using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float rotationSpeed = 180.0f;
    public float thrustForce = 5.0f;
    public float maxSpeed = 10.0f;
    public float accelerationRate = 2.0f; // Adjust this value to control acceleration
    public float decelerationRate = 4.0f; // Adjust this value to control deceleration


    [SerializeField] float currentSpeed ;
    private Rigidbody2D rb;


    private float rotationInput;
    private float thrustInput;

    private Vector2 screenBounds;
    private Vector2 currentPosition;
    private Vector3 forwardThrust;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        WrapShipInsideScreen();
    }

    private void FixedUpdate()
    {
        RotateShip();
        MoveShip();
    }

    void RotateShip()
    {
        rotationInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.forward * -rotationInput * rotationSpeed * Time.deltaTime);
        float rotationAngle = -rotationInput * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotationAngle);
    }

    void MoveShip()
    {        
        thrustInput = Mathf.Clamp( Input.GetAxis("Vertical"),0,1);

        if (thrustInput > 0)
        {
            // Accelerate if the vertical input is positive (e.g., W or Up Arrow)
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, Time.deltaTime * accelerationRate);
        }
        else
        {
            // Decelerate if the vertical input is not positive (e.g., no input or S or Down Arrow)
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, Time.deltaTime * decelerationRate);
        }
        
        forwardThrust = transform.up.normalized * currentSpeed;
        rb.velocity = forwardThrust;
        
    }
    void WrapShipInsideScreen()
    {
        // Screen wrapping logic.
        currentPosition = transform.position;

        if (Mathf.Abs(currentPosition.x) > screenBounds.x)
        {
            currentPosition.x = currentPosition.x > 0 ? -screenBounds.x + 0.1f : screenBounds.x - 0.1f;
            transform.position = currentPosition;
        }
        else if (Mathf.Abs(currentPosition.y) > screenBounds.y)
        {
            currentPosition.y = currentPosition.y > 0 ? -screenBounds.y + 0.1f : screenBounds.y - 0.1f;
            transform.position = currentPosition;
        }
    }

   


}
