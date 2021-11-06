using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    bool isGround;
    bool isCube;

    private Vector3 lastMouse = new Vector3(255, 255, 255);
    float camSens = 0.25f;
    public GameObject player;
    public GameObject Ground;
    public GameObject TimeZone;
    public GameObject TimeZone2;
    private Rigidbody _rb;
    public float JumpSpeed = 20;
    float moveHorizontal;
    float moveVertical;
    float Jump;
    float mainSpeed = 10.0f;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("TimeZone"))
        {
            Debug.Log("Вход в зону замедления");
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        if (col.collider.CompareTag("TimeZone2"))
        {
            Debug.Log("Вход в зону ускорения");
            Time.timeScale = 2f;
        }
    }
     private void OnCollisionStay(Collision other)
     {
         if (other.gameObject.tag == "Ground") {

             isGround = true;
         }
     }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isCube = false;
        }

        if (other.gameObject.tag == "Cube")
        {
            isGround = false;
        }
        if (other.collider.CompareTag("TimeZone"))
        {
            Debug.Log("Выход из зоны замедления");
            Time.timeScale = 1; 
        }
        if (other.collider.CompareTag("TimeZone2"))
        {
            Debug.Log("Выход из зоны ускорения");
            Time.timeScale = 1;
        }
    }
    void FixedUpdate()
    {

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        MovementLogic();
    }
    private void MovementLogic()
    {
        

        
            moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
            moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        if (isGround || isCube)
        {
            Jump = Input.GetAxis("Jump") * Time.deltaTime * JumpSpeed;

            Vector3 movement = new Vector3(moveHorizontal, Jump, moveVertical);

          //  _rb.AddForce(movement * Speed, ForceMode.Impulse);
           GetComponent<Rigidbody>().AddForce(transform.up * Jump, ForceMode.Impulse);
        }
        transform.Translate(new Vector3(moveHorizontal * mainSpeed, 0.0f, moveVertical * mainSpeed));
    }
    
}
