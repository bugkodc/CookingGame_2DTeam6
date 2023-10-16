using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDish : MonoBehaviour
{
    Dish dish;
    private void Start()
    {
        dish = GetComponent<Dish>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "table")
        {
            Table table = collision.gameObject.GetComponent<Table>();
            bool a = table.CheckServeFood(dish.DataDish);
            if(a == true)
            {
                Debug.Log("Dung mon roi");
            }
            else
            {
                Debug.Log("Sai mon roi");
            }
        }
    }
}
