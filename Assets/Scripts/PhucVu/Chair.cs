using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    bool hasCustomer = false;
    public bool HasCustomer { get { return hasCustomer; }  }
    ComboTableChair comboTableChair;
    private void Start()
    {
        comboTableChair = GetComponentInParent<ComboTableChair>();
    }
    public void CustomerSitDown()
    {
        hasCustomer = true;
    }
    public void CustomerStandUp()
    {
        hasCustomer= false;
    }
}
