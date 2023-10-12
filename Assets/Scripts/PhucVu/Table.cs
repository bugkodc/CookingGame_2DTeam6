using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    bool hasDish = false;
    public bool HasDish { get { return hasDish; } }
    [SerializeField] ComboTableChair comboTableChair;
    private void Start()
    {
        comboTableChair = GetComponentInParent<ComboTableChair>();
    }
    public void DisPlayFood()
    {
        hasDish = true;
    }
    public void CleanTable()
    {
        hasDish = false;
        comboTableChair.dinnerTable.bowlTray.AddBowl();
    }
}
