using TMPro;
using UnityEngine;

public class BuyStockFrameController : MonoBehaviour
{

    public StockInfo info;

    public StockBox boxToSpawn;

    public TMP_Text nameText,priceText,amountInBoxText,boxPriceText,buttonText;

    private float boxCost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateFrameInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFrameInfo()
    {
        info = StockinfoController.instance.GetInfo(info.name);

        nameText.text = info.name;
        priceText.text  = "$" + info.Price.ToString("F2");
        
        int boxAmount = boxToSpawn.GetStockAmount(info.typeOfStock);
        amountInBoxText.text = boxAmount.ToString() + "per box";


        boxCost = boxAmount * info.Price;
        boxPriceText.text = "Box: $" + boxCost.ToString("F2");

        buttonText.text = "PAY: $" + boxCost.ToString("F2");
    }


    public void BuyBox()
    {
        if (StoreController.instance.CheckMoneyAvailable(boxCost))
        {
            StoreController.instance.SpendMoney(boxCost);
            Instantiate(boxToSpawn,StoreController.instance.stockSpawnPoint.position,Quaternion.identity).SetupBox(info);

        }
    }
}
