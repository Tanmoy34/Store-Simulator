using UnityEngine;

public class ShelfSpaceController : MonoBehaviour
{
    public StockInfo info;

    int amountOnShelf;

    public void PlaceStock(StockObject objectToPlace)
    {
        bool preventPlaceing = true;
        Debug.Log(amountOnShelf);
        if (amountOnShelf == 0)
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
            
            amountOnShelf += 1;
        }
        
    }


}
