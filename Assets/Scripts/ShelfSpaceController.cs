using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    public StockInfo info;

    

    public List<StockObject> objectsOnShelf; 
    public List<Transform> bigDrinkPoints;
    public List<Transform> cerealPoints;
    public List<Transform> tubeChipsPoints;
    public List<Transform> fruitsPoints;
    public List<Transform> largeFruitsPoints;
    public TMP_Text shelfLebel;

    public void PlaceStock(StockObject objectToPlace)
    {
        bool preventPlaceing = true;
        
        if (objectsOnShelf.Count == 0)
        {
            info = objectToPlace.info;
            
            preventPlaceing =false;
            
        }
        else
        {
           
            if(info.name == objectToPlace.info.name)
            {
               preventPlaceing = false;

                switch (info.typeOfStock)
                {
                    case StockInfo.StockType.bigDrink:
                      if(objectsOnShelf.Count>= bigDrinkPoints.Count)
                        {
                            preventPlaceing = true;
                        }  
                        break;
                    case StockInfo.StockType.cereal :
                        if (objectsOnShelf.Count >= cerealPoints.Count)
                        {
                            preventPlaceing = true;
                        }
                        break;
                    case StockInfo.StockType.chipsTube :
                        if (objectsOnShelf.Count >= tubeChipsPoints.Count)
                        {
                            preventPlaceing = true;
                        }
                        break;
                    case StockInfo.StockType.fruit:
                        if (objectsOnShelf.Count >= fruitsPoints.Count)
                        {
                            preventPlaceing = true;
                        }
                        break;
                    case StockInfo.StockType.fruitLarge :
                        if (objectsOnShelf.Count >= largeFruitsPoints .Count)
                        {
                            preventPlaceing = true;
                        }
                        break;

                } 



               
            }

        }
        if(preventPlaceing == false)
        {
            //objectToPlace.transform.SetParent(transform);
            objectToPlace.MakePlaced();

            

            switch (info.typeOfStock)
            {
                case StockInfo.StockType.bigDrink:
                    objectToPlace.transform.SetParent(bigDrinkPoints[objectsOnShelf.Count]);
                    break;
                case StockInfo.StockType.cereal:
                    objectToPlace.transform.SetParent(cerealPoints[objectsOnShelf.Count]);
                    break;
                case StockInfo.StockType.chipsTube:
                    objectToPlace.transform.SetParent(tubeChipsPoints[objectsOnShelf.Count]);
                    break;
                case StockInfo.StockType.fruit:
                    objectToPlace.transform.SetParent(fruitsPoints[objectsOnShelf.Count]);
                    break;
                case StockInfo.StockType.fruitLarge:
                    objectToPlace.transform.SetParent(largeFruitsPoints[objectsOnShelf.Count]);
                    break;

            }


            objectsOnShelf.Add(objectToPlace);

           UpdateDisplayPrice(info.currentPrice);
        }
        
    }
    public StockObject GetStock()
    {
    
        StockObject objectToReturn = null;
        if (objectsOnShelf.Count > 0)
        {
            objectToReturn = objectsOnShelf[objectsOnShelf.Count - 1];
            objectsOnShelf.RemoveAt(objectsOnShelf.Count - 1);
        }

        if (objectsOnShelf.Count == 0)
        {
            shelfLebel.text =string.Empty;
        }
        return objectToReturn;
    }

    public void StartPriceUpdate()
    {
        if(objectsOnShelf.Count> 0)
        {
            UIController.instance.OpenUpdatePrice(info);
        }
    }

    public void UpdateDisplayPrice(float price)
    {
        if (objectsOnShelf.Count > 0)
        {
            info.currentPrice = price;
            shelfLebel.text = "$" + info.currentPrice;
        }
        

    }

   


}
