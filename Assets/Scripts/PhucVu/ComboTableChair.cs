using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboTableChair : MonoBehaviour
{
    public DinnerTable dinnerTable;
    [SerializeField] Table table;
    public Table getTable {  get { return table; } }

    [SerializeField] Chair chair;
    public Chair getChair { get { return chair; } }

    private void Start()
    {
        dinnerTable = gameObject.GetComponentInParent<DinnerTable>();
    }
}
