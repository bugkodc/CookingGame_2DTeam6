using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    Dish orderFood;
    float timeWait;
    [SerializeField] DinnerTable dinnerTable;
    ComboTableChair comboTableChair;
    Door door;
    private void OnEnable()
    {
        dinnerTable = FindObjectOfType<DinnerTable>();
        door = FindObjectOfType<Door>();
        EnterRestaurant();
    }
    void EnterRestaurant()
    {
        FindTable();
        GotoTable();
        SitDown();
        ThinkOrder();
    }
    
    void FindTable()
    {
        if(dinnerTable.CheckEmptyTable() == true)
        {
            comboTableChair = dinnerTable.GetEmptyTable();
        }
    }
    void GotoTable()
    {
        Vector3 chairEmpty = comboTableChair.getChair.gameObject.transform.position;
        transform.position = chairEmpty;
    }
    void SitDown()
    {
        comboTableChair.getChair.CustomerSitDown();
        float rd = Random.Range(5f, 15f);
        Invoke("StandUp", rd);
    }
    void ThinkOrder()
    {

    }
    void StandUp()
    {
        comboTableChair.getChair.CustomerStandUp();
        comboTableChair.getTable.CleanTable();
        door.CustomerOut();
        gameObject.SetActive(false);
    }
    
    void Evalute()
    {

    }
    void VoteService()
    {

    }
    void PayForFood()
    {

    }
}
