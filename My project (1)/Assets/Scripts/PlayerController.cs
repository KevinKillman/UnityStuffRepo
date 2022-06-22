using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private int mag;
    private float movementX;
    private float movementY;
    Keyboard keyboard = Keyboard.current;
    public float speed = 0;
    public Environ environ;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI pickupsText;
    public TextMeshProUGUI winText;
    private float speedMod = 1f;
    private float drag = 1f;
    private float maxSpeed=12f;
    private float maxAccel;
    public bool jumped = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        mag = 0;
        SetCount();
        winText.gameObject.SetActive(false);
        rb.maxLinearVelocity = maxSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        if ( count > 0 ) { mag = count; };
        movement = movement * speed * speedMod;
        rb.AddForce(movement, ForceMode.Force);
    }

    public void Jump(Rigidbody rbX)
    {
        Vector3 movement = new Vector3(0, 500, 0);
        rb.AddForceAtPosition(movement, rbX.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("SpeedUp") )
        {
            other.gameObject.SetActive(false);
            count++;
            speed++;
            maxSpeed+=10;
            environ.pickups.Remove(other.gameObject);
            SetCount();
        }
        if ( other.gameObject.CompareTag("Hopper") )
        {
            Jump(rb);
        }
        if (other.gameObject.CompareTag("Surface"))
        {
            var surface = other.gameObject.GetComponent<ISurface>();
            speedMod = surface.SpeedMod;
            drag = surface.Drag;
            jumped = false;
        }
        if (other.gameObject.CompareTag("Death") )
        {
            Die();
        }
    }

    private void Die()
    {
        transform.position= new Vector3(0,1,0);

    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();
        //Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    void SetCount()
    {
        var environCount = environ.pickups.Count;
        countText.text = "Count:" + count.ToString();
        pickupsText.text = "Objects Left:" + environCount.ToString();
        if (environCount == 0 ) { winText.gameObject.SetActive(true); }
    }
}
