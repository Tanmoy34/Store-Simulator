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

    public Rigidbody rb;
    public Collider col;

    private bool isHeld;
    public float moveSpeed = 5f;
    
    public GameObject flap1,flap2;

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
        if(isHeld == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, moveSpeed * Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, moveSpeed * Time.deltaTime); 
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


    public void PickUp()
    {
        rb.isKinematic = true;
        isHeld = true;
        
        col.enabled = false;
    }


    public void Release()
    {
        isHeld = false;
        rb.isKinematic = false;
        col.enabled = true;
    }


    public void OpenCloseBox()
    {
        if(flap1.activeSelf == true)
        {
            flap1.SetActive(false);
            flap2.SetActive(false);
        }
        else
        {
            flap1.SetActive(true);
            flap2.SetActive(true);

        }
    }

    public void PlaceStockOnShelf(ShelfSpaceController shelf)
    {
        if (stocksInBox.Count > 0)
        {
            shelf.PlaceStock(stocksInBox[stocksInBox.Count -1]);
            if(stocksInBox[stocksInBox.Count-1].isPlaced == true)
            {
                stocksInBox.RemoveAt(stocksInBox.Count - 1);
            }
        }
        if(flap1.activeSelf == true)
        {
            OpenCloseBox();
        }
    } 






}
