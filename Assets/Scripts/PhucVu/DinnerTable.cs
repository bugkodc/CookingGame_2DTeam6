using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class DinnerTable : MonoBehaviour
{
    [SerializeField] ComboTableChair[] listTable;
    public DoorOut doorOut;
    public Door door;
    public BowlTray bowlTray;
    public Menu menu;

    private void Start()
    {
        if(doorOut == null)
        {
            doorOut = FindObjectOfType<DoorOut>();
        }
        if(door == null)
        {
            door = FindObjectOfType<Door>();
        }
        if(bowlTray == null)
        {
            bowlTray = FindObjectOfType<BowlTray>();
        }
        if(menu == null)
        {
            menu = FindObjectOfType<Menu>();
        }
    }
    public bool CheckEmptyTable()
    {
        foreach (ComboTableChair combo in listTable)
        {
            if (combo.getChair.HasCustomer == false) return true;
        }
        return false;
    }

    public ComboTableChair GetEmptyTable()
    {
        foreach (ComboTableChair combo in listTable)
        {
            if(combo.getChair.HasCustomer == false)
            {
                
                return combo;
            }
        }
        return null;
    }
    public int GetCountCombo()
    {
        return listTable.Length;
    }
}
