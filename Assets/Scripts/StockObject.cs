using NUnit.Framework;
using UnityEngine;

public class StockObject : MonoBehaviour
{
    public StockInfo info;
    public float moveSpeed = 5f;
    public bool isPlaced;
    public Rigidbody rb;
    public Collider col;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
        info = StockinfoController.instance.GetInfo(info.name);
    }

    void Update()
    {
         
        if(isPlaced == true)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,Vector3.zero,moveSpeed* Time.deltaTime);
            transform.localRotation = Quaternion.Slerp(transform.localRotation,Quaternion.identity,moveSpeed*Time.deltaTime);
        }
    }
    public void PickUp()
    {
        rb.isKinematic = true;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        isPlaced = false;
        col.enabled =false;
    }

    public void MakePlaced()
    {
        rb.isKinematic = true;
        isPlaced = true;
        col.enabled =false;
        
    }

    public void Release()
    {
        rb.isKinematic =false;
        col.enabled =true;
    }


    public void PlaceInBox()
    {
        rb.isKinematic = true;
        col.enabled = false;
    }
}
