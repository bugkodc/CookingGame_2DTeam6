using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    DataDish orderFoodCustomer;
    bool hasDish = false;
    public bool HasDish { get { return hasDish; } }
    ComboTableChair comboTableChair;
    private void Start()
    {
        comboTableChair = GetComponentInParent<ComboTableChair>();
    }
    public void SetOrderFoodCustomer(DataDish orderFood)
    {
        orderFoodCustomer = orderFood;
    }
    public void CheckServeFood(DataDish serveFood)
    {
        if (orderFoodCustomer == null) return;
        if(serveFood == orderFoodCustomer)
        {
            DisPlayFood();
        }
    }
    public void DisPlayFood()
    {
        hasDish = true;
        comboTableChair.customerNow.StartEat();
    }
    public void CleanTable()
    {
        if (hasDish)
        {
            comboTableChair.dinnerTable.bowlTray.AddBowl();
        }
        hasDish = false;
    }
}
