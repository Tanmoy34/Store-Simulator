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
    public Camera theCam;
    
    private float ySpeed;
    private float horizontalRotation, vertualRotation;
    public float minLookAngle,maxLookAngle;



    public LayerMask stockLayerMask;
    public float intractonRange = 5f;
    private StockObject heldPickup;
    public Transform holdPoint;
    public float TrowForce = 10f;



    public LayerMask shelfLayerMask;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        
        PlayerMove();
        Intract();
    
    }


    void PlayerMove()
    {
        Vector2 lookinput = lookAction.action.ReadValue<Vector2>();



        horizontalRotation = horizontalRotation + lookinput.x * Time.deltaTime * lookSpeed;
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        vertualRotation +=  lookinput.y * Time.deltaTime * lookSpeed;
        vertualRotation = Mathf.Clamp(vertualRotation, minLookAngle, maxLookAngle);


        theCam.transform.localRotation = Quaternion.Euler(vertualRotation, 0f, 0f);

        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();


        Vector3 verticleMove = transform.forward * moveInput.y;
        Vector3 horizontalMove = transform.right * moveInput.x;

        Vector3 moveAmount = horizontalMove + verticleMove;
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


        ySpeed = ySpeed + (Physics.gravity.y * Time.deltaTime);


        moveAmount.y = ySpeed;

        charCon.Move(moveAmount * Time.deltaTime);
    }









    void Intract()
    {
        Ray ray = theCam.ViewportPointToRay(new Vector3(.5f,.5f,0f));
        RaycastHit hit;
        if(heldPickup == null) //when we Do not have Something
        {
             if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (Physics.Raycast(ray, out hit, intractonRange, stockLayerMask))
                {
                   


                    heldPickup = hit.collider.GetComponent<StockObject>();
                    heldPickup.transform.SetParent(holdPoint);
                    heldPickup.PickUp();
                }
            }
        }
        else //when we Have something in the hand
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                
                if(Physics.Raycast(ray,out hit,intractonRange,shelfLayerMask))
                {
                    /*
                    heldPickup.MakePlaced();
                    heldPickup.transform.SetParent(hit.transform);
                    heldPickup = null;
                    */



                    hit.collider.GetComponent<ShelfSpaceController>().PlaceStock(heldPickup);


                    if (heldPickup.isPlaced)
                    {
                        heldPickup = null;
                    }
                }

                
            }



            if (Mouse.current.rightButton.wasPressedThisFrame )
             {
            
                //Rigidbody pickupRb =  heldPickup.GetComponent<Rigidbody>();
                heldPickup.Release();
                heldPickup.rb.AddForce(theCam.transform.forward * TrowForce,ForceMode.Impulse);


                heldPickup.transform.SetParent(null);
                heldPickup = null;

             }
        }
        
    }

    
    


}
