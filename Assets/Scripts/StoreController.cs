using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoreController : MonoBehaviour
{
    public static StoreController instance;
    public Transform stockSpawnPoint;

    public float currentMoney = 1000f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIController.instance.UpdateMoney(currentMoney);
    }


    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            AddMoney(100f);
        }
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            if (CheckMoneyAvailable(250f))
            {
                SpendMoney(250f);
            }
        }
        
    }

    public void AddMoney(float amountToAdd)
    {
        currentMoney += amountToAdd;
        UIController.instance.UpdateMoney(currentMoney);
    }

    public void SpendMoney(float amountToSpend)
    {
        
        currentMoney -= amountToSpend;
        if (currentMoney < 0)
        {
            currentMoney = 0;
        }
        UIController.instance.UpdateMoney(currentMoney);
    }

    public bool CheckMoneyAvailable(float amountToCheck)
    {
        bool hasEnough = false;
        if(currentMoney>= amountToCheck)
        {
            hasEnough = true;
        }
        return hasEnough;
    }
}
