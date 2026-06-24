using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //takeing  movement
    public InputActionReference moveAction;
    public InputActionReference jumbAction;
    public InputActionReference lookAction;
    public CharacterController charCon;
    
    public float moveSpeed = 10f;
    public float jumpForce =2f;
    public float lookSpeed = 5f;
    public Transform theCam;
    
    private float ySpeed;
    private float horizontalRotation, vertualRotation;
 
    public float minLookAngle,maxLookAngle;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        Vector2 lookinput = lookAction.action.ReadValue<Vector2>();


        
        horizontalRotation = horizontalRotation + lookinput.x * Time.deltaTime * lookSpeed;
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        vertualRotation = vertualRotation + lookinput.y * Time.deltaTime * lookSpeed;
        vertualRotation = Mathf.Clamp( vertualRotation,minLookAngle,maxLookAngle);
        theCam.localRotation = Quaternion.Euler(vertualRotation, 0f, 0f);

        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
       

         Vector3 verticleMove = transform.forward* moveInput.y;
         Vector3 horizontalMove = transform.right* moveInput.x;
          
        Vector3 moveAmount  = horizontalMove + verticleMove;
        moveAmount = moveAmount.normalized;
         moveAmount = moveAmount * moveSpeed;


        //jumping
        if (charCon.isGrounded == true)
        {
            ySpeed = 0f;

            if (jumbAction.action.WasPressedThisFrame())
            {
                ySpeed = jumpForce;
            }
        }


        ySpeed = ySpeed+ (Physics.gravity.y * Time.deltaTime);


        moveAmount.y = ySpeed;
         
         charCon.Move(moveAmount * Time.deltaTime);
 

    
    }


    void PlayerMove()
    {
        
    }

    



}
