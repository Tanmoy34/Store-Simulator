using System.Collections.Generic;
using UnityEngine;

public class StockinfoController : MonoBehaviour
{
    public List<StockInfo> foodInfo;
    public List<StockInfo> ProduceInfo;
    [SerializeField] List<StockInfo> allStock = new List<StockInfo>();
    public static StockinfoController instance;
    

    void Awake()
    {
        instance = this;
        allStock.AddRange(foodInfo);
        allStock.AddRange(ProduceInfo); 
    }
    void Update()
    {
        
    }

    public StockInfo GetInfo(string stockName)
    {
        StockInfo infoToReturn = null;
        for (int i = 0; i < allStock.Count; i++)
        {
            if (allStock[i].name == stockName)
            {
                infoToReturn = allStock[i];
            }
        }

        return infoToReturn;
    }
}
