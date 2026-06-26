using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    public GameObject updatePricePanel;
    void Awake()
    {
       instance =this; 
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OpenUpdatePrice()
    {
        updatePricePanel.SetActive(true);
        Cursor.lockState  = CursorLockMode.None;
    }
    public void CloseUpdatePrice()
    {
        updatePricePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
