using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public TMP_Text basePriceText;
    public TMP_Text currentPriceText;
    public TMP_InputField priceInputField;
    
    private StockInfo activeStockInfo;
    public GameObject updatePricePanel;


    public TMP_Text moneyText;
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

    public void OpenUpdatePrice(StockInfo stockToUpdate)
    {
        updatePricePanel.SetActive(true);
        Cursor.lockState  = CursorLockMode.None;
        
        basePriceText.text = "$" + stockToUpdate.Price.ToString("F2");
        currentPriceText.text   = "$" + stockToUpdate.currentPrice.ToString("F2");
        activeStockInfo = stockToUpdate;

        priceInputField.text = stockToUpdate.currentPrice.ToString(); 

    }
    public void CloseUpdatePrice()
    {
        updatePricePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;


        
    }

    public void ApplyPriceUpdate()
    {

        
        
            activeStockInfo.currentPrice =float.Parse(priceInputField.text);


            currentPriceText.text = "$" + activeStockInfo.currentPrice.ToString("F2");

            StockinfoController.instance.UpdatePrice(activeStockInfo.name,activeStockInfo.currentPrice);

            CloseUpdatePrice();
        
        
    }

    public void UpdateMoney(float currentMoney)
    {
        moneyText.text ="$" +  currentMoney.ToString("F2");
    }
}
