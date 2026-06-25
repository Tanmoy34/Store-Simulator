using System.Collections.Generic;
using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    public StockInfo info;

    

    public List<StockObject> objectOnShelf; 
    public void PlaceStock(StockObject objectToPlace)
    {
        bool preventPlaceing = true;
        
        if (objectOnShelf.Count == 0)
        {
            info = objectToPlace.info;
            
            preventPlaceing =false;
            

            
            
        }
        else
        {
           
            if(info.name == objectToPlace.info.name)
            {
               preventPlaceing = false; 
            }

        }
        if(preventPlaceing == false)
        {
            objectToPlace.transform.SetParent(transform);
            objectToPlace.MakePlaced();

            objectOnShelf.Add(objectToPlace);
        }
        
    }
    public StockObject GetStock()
    {
    
        StockObject objectToReturn = null;
        if (objectOnShelf.Count > 0)
        {
            objectToReturn = objectOnShelf[objectOnShelf.Count - 1];
            objectOnShelf.RemoveAt(objectOnShelf.Count - 1);
        }
        return objectToReturn;
    }


}
