using System.Collections.Generic;
using UnityEngine;

public class StockBox : MonoBehaviour
{

    public StockInfo info;
    public List<Transform> bigDrinkPoints;
    public List<Transform> cerealPoints;
    public List<Transform> tubeChipsPoints;
    public List<Transform> fruitsPoints;
    public List<Transform> largeFruitsPoints;

    public bool testFill;

    public List<StockObject> stocksInBox;


    void Start()
    {
        
    }

   
    void Update()
    {
        if(testFill == true)
        {
            testFill = false;

            SetupBox(info);
        }
    }

    public void SetupBox (StockInfo stockType)
    {
        info = stockType;

        List<Transform> activePoints = new List<Transform>();
        switch (info.typeOfStock)
        {
            case StockInfo.StockType.bigDrink :
             activePoints.AddRange(bigDrinkPoints);
             break;

            case StockInfo.StockType.cereal :
             activePoints.AddRange(cerealPoints);
             break;
            case StockInfo.StockType.chipsTube :
             activePoints.AddRange(tubeChipsPoints);
             break;
            case StockInfo.StockType.fruit:
             activePoints.AddRange(fruitsPoints);
             break;
            case StockInfo.StockType.fruitLarge:
             activePoints.AddRange(largeFruitsPoints);
             break;
        }

        if(stocksInBox.Count == 0)
        {
            for(int i = 0; i<activePoints.Count; i++)
            {
                StockObject stock = Instantiate(stockType.stockObject,activePoints[i]);
                
                stock.transform.localPosition = Vector3.zero;
                stock.transform.rotation = Quaternion.identity;

                stocksInBox.Add(stock);
                stock.PlaceInBox();
            }
        }
    }



    
}
