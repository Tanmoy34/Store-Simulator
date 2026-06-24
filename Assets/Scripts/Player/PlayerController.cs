using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    //takeing  movement
    public InputActionReference moveAction;
    public float moveSpeed = 10f;

    void Start()
    {
        
    }

    
    void Update()
    {

        
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        float frameIndepaendant = moveSpeed * Time.deltaTime;
        Vector3 newTransform = transform.position +  new Vector3(moveInput.x * frameIndepaendant, 0f, moveInput.y *frameIndepaendant);

        transform.position = newTransform ;

    
    }



}
