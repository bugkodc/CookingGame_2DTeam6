using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] DataDish orderFoodCustomer;
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
    public bool CheckServeFood(DataDish serveFood)
    {
        if (orderFoodCustomer == null) return false;
        if(serveFood == orderFoodCustomer)
        {
            DisPlayFood();
            return true;
        }
        return false;
    }
    public void DisPlayFood()
    {
        if (hasDish == true) return;
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
        orderFoodCustomer = null;
    }
}
