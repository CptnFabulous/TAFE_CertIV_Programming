/*
using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Movement
//This script requires the component Character controller

    [RequireComponent(typeof (CharacterController))]
    [AddComponentMenu("Intro PRG/RPG/Player/Movement")]
public class Movement : MonoBehaviour 
{
    #region Variables
    //[Header("Characters MoveDirection")]
    //vector3 called moveDirection
    //we will use this to apply movement in worldspace
    //private CharacterController (https://docs.unity3d.com/ScriptReference/CharacterController.html) charC
    //[Header("Character Variables")]
    //public float variables jumpSpeed, speed, gravity

    [Header("Characters MoveDirection")]
    Vector2 MovementInput;
    Vector2 CameraInput;
    Vector3 moveDirection; //we will use this to apply movement in worldspace
    float Vertical;

    [Header("Character Variables")]
    private CharacterController charC;
    public GameObject head;
    public float speed;
    public float jumpSpeed;
    public float gravity;
    public float mouseSensX;
    public float mouseSensY;
    #endregion
    #region Start
    //charc is on this game object we need to get the character controller that is attached to it

    private void Start()
    {
        charC = GetComponent<CharacterController>();
    }
    #endregion
    #region Update
    //if our character is grounded
    //we are able to move in game scene meaning
    //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
    //Input(https://docs.unity3d.com/ScriptReference/Input.html)
    //moveDir is equal to a new vector3 that is affected by Input.Get Axis.. Horizontal, 0, Vertical
    //moveDir is transformed in the direction of our moveDir
    //our moveDir is then multiplied by our speed
    //we can also jump if we are grounded so
    //in the input button for jump is pressed then
    //our moveDir.y is equal to our jump speed
    //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
    //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime

    void Update()
    {
        
        
        if (charC.isGrounded)
        {
            //Vertical = gravity;
            if (Input.GetButtonDown("Jump"))
            {
                Vertical = jumpSpeed;
            }
        }
        else
        {
            Vertical -= gravity * Time.deltaTime;
        }

        
        CameraInput.x = Input.GetAxis("Mouse X") * mouseSensX;
        CameraInput.y -= Input.GetAxis("Mouse Y") * mouseSensY;
        CameraInput.y = Mathf.Clamp(CameraInput.y, -90, 90);
        transform.Rotate(0, CameraInput.x, 0);
        head.transform.localRotation = Quaternion.Euler(CameraInput.y, 0, 0);

        MovementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MovementInput.Normalize();
        moveDirection = new Vector3(MovementInput.x * speed, Vertical, MovementInput.y * speed);
        print(moveDirection);

        moveDirection = transform.rotation * moveDirection;


        charC.Move(moveDirection); // Uses a function in the CharacterController class to move the character based on moveDirection
        

        
        /*
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (charC.isGrounded)
        {
            //Vertical = gravity;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y = gravity * Time.deltaTime;

        //moveDirection = transform.rotation * moveDirection;


        charC.Move(moveDirection * Time.deltaTime); // Uses a function in the CharacterController class to move the character based on moveDirection
        

    }

    #endregion
}
*/

using UnityEngine;
using System.Collections;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

public class Movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    [HideInInspector]
    public static bool canMove = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (canMove)
        {
            if (controller.isGrounded)
            {
                // We are grounded, so recalculate
                // move direction directly from axes

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * speed;

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            // Apply gravity
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

            // Move the controller
            controller.Move(moveDirection * Time.deltaTime);
        }
        
    }
}