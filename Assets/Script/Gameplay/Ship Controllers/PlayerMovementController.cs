using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour ,IPowerUp
{
    [Header("Current Progress")]
    [SerializeField] So_MovementData activeMovementData;
    [SerializeField] float currentSpeed ;


    private PlayerManager playerManager;
    private Rigidbody2D rb;
    private float rotationInput;
    private float thrustInput;
    private Vector2 screenBounds;
    private Vector2 currentPosition;
    private Vector3 forwardThrust;
    private So_MovementData defaultMovementData;
    

    public PowerUpType powerType => PowerUpType.Movement;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        defaultMovementData = playerManager.GetGameManager().GetDefaultMovementData();

        Register_PowerUpListners();
        SwitchMovementData(defaultMovementData);
    }


    private void FixedUpdate()
    {
        WrapShipInsideScreen();
        RotateShip();
        MoveShip();
    }

    void RotateShip()
    {
        rotationInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.forward * -rotationInput * rotationSpeed * Time.deltaTime);
        float rotationAngle = -rotationInput * activeMovementData.rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotationAngle);
    }

    void MoveShip()
    {        
        thrustInput = Mathf.Clamp( Input.GetAxis("Vertical"),0,1);

        if (thrustInput > 0)
        {
            // Accelerate if the vertical input is positive (e.g., W or Up Arrow)
            currentSpeed = Mathf.MoveTowards(currentSpeed, activeMovementData.maxSpeed, Time.deltaTime * activeMovementData.accelerationRate);
        }
        else
        {
            // Decelerate if the vertical input is not positive (e.g., no input or S or Down Arrow)
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, Time.deltaTime * activeMovementData.decelerationRate);
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

   
    void SwitchMovementData(So_MovementData newMovementData)
    {
        activeMovementData = newMovementData;
    }



    void Register_PowerUpListners()
    {
        if (playerManager == null)
            Debug.LogError("We got an issue here, Null Manager");
        playerManager.Register_PowerUpListners(this);
    }

    public void ActivatePower(ScriptableObject data)
    {
        Debug.Log("PowerUp : Activating Movement Power -" + data.name);
        So_MovementData newMovementData = (So_MovementData)data;
        if (newMovementData != null)
        {
            SwitchMovementData(newMovementData);
        }
        else
            Debug.LogError("Some issue is here in this powerUp :" + powerType + " ," + data.name);
    }

    public void DeactivatePower()
    {
        Debug.Log("PowerUp : DeActivating Movement Power ");
        SwitchMovementData(defaultMovementData);
    }
}
