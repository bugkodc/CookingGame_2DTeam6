using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] List<DataDish>  menuDish;
    public List<DataDish> MenuDish { get { return menuDish; } }

    public void addNewDishToMenu(Dish newDish)
    {
        menuDish.Add(newDish.DataDish);
    }
}
