using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] DinnerTable dinnerTable;

    GameObject[] poolCustomer;
    //int poolSizeCustomer;
    [SerializeField] float timeSpawn = 6;
    float countTime = 0;

    

    private void Start()
    {
        //poolSizeCustomer = dinnerTable.GetCountCombo();
        if(dinnerTable == null)
        {
            dinnerTable = FindObjectOfType<DinnerTable>();
        }
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
    
    
}
