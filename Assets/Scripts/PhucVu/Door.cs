using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] DinnerTable dinnerTable;

    GameObject[] poolCustomer;
    //int poolSizeCustomer;
    float timeSpawn = 3;
    float countTime = 0;

    

    private void Start()
    {
        //poolSizeCustomer = dinnerTable.GetCountCombo();
        CustomerGoRestaurant();
        
    }
    private void Update()
    {
        countTime += Time.deltaTime;
        if(countTime > timeSpawn)
        {
            CustomerGoRestaurant();
            countTime = 0;
        }
    }
    public void CustomerGoRestaurant()
    {
        if (dinnerTable.CheckEmptyTable() == false) return;
        GameObject Customer = Instantiate(customerPrefab, this.transform);
    }
    
    public void CustomerOut()
    {
        countTime = 0;
    }
}
