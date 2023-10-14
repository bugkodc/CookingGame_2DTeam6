using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] DinnerTable dinnerTable;
    [SerializeField] SpriteRenderer spriteDishOrder;

    //Thời gian chờ món ăn
    float timeWait;
    float countTimeWait = 0;

    //Thời gian ăn món ăn đó
    float timeEat;
    float countTimeEat = 0;

    //Có món ăn chưa ?
    bool hasFood = false;

    //Món ăn order
    DataDish orderFood;

    ComboTableChair comboTableChair;
    Door door;
    
    private void OnEnable()
    {
        dinnerTable = FindObjectOfType<DinnerTable>();
        door = FindObjectOfType<Door>();
        EnterRestaurant();
    }
    private void Update()
    {
        Waiting();
        Eating();
    }
    void EnterRestaurant()
    {
        FindTable();
        GotoTable();
        SitDown();
        ThinkOrder();
        Order();
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
        comboTableChair.customerNow = this;
        Vector3 chairEmpty = comboTableChair.getChair.gameObject.transform.position;
        transform.position = chairEmpty;
    }
    void SitDown()
    {
        comboTableChair.getChair.CustomerSitDown();
        hasFood = false;
        timeWait = Random.Range(5f, 15f);
    }
    void ThinkOrder()
    {
        int countMenuDish = dinnerTable.menu.MenuDish.Count;
        if (countMenuDish == 0)
        {
            Debug.LogWarning("MenuDish list is empty. Cannot select a random dish.");
            return ;
        }

        int randomIndex = Random.Range(0, countMenuDish);
        DataDish randomDish = dinnerTable.menu.MenuDish[randomIndex];

        orderFood = randomDish;
    }
    void Order()
    {
        spriteDishOrder.sprite = orderFood.ImgDish;
    }
    void Waiting()
    {
        if (!hasFood) countTimeWait += Time.deltaTime;
        if (countTimeWait >= timeWait) StandUp();
    }
    public void StartEat()
    {
        hasFood = true;
        timeEat = orderFood.TimeEat;
        spriteDishOrder.sprite = null;
    }
    void Eating()
    {
        if (timeEat == 0) return;
        if (hasFood) countTimeEat += Time.deltaTime;
        if (countTimeEat >= timeEat)
        {
            FinishEat();
        }
    }
    public void FinishEat()
    {

    }
    void StandUp()
    {
        comboTableChair.getChair.CustomerStandUp();
        comboTableChair.getTable.CleanTable();
        door.CustomerOut();

        //Setup lại thời gian
        countTimeWait = 0;
        countTimeEat = 0;
        timeEat = 0;
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
