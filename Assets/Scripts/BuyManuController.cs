using UnityEngine;

public class BuyManuController : MonoBehaviour
{

    public GameObject stockPanel,furniturePanel;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }


    public void OpenStockPanel()
    {
        stockPanel.SetActive(true);
        furniturePanel.SetActive(false);
    }
    public void OpenFurniturePanel()
    {
        furniturePanel.SetActive(true);
        stockPanel.SetActive(false);
    }
}
