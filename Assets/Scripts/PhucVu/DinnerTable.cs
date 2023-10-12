using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class DinnerTable : MonoBehaviour
{
    [SerializeField] ComboTableChair[] listTable;
    public BowlTray bowlTray;
    

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
