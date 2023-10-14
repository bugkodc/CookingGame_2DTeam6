using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "DataDish", order = 1)]
public class DataDish : ScriptableObject
{
    [SerializeField] string nameDish;
    [SerializeField] float timeCook;
    [SerializeField] float timeEat;
    [SerializeField] bool hasCook;
    [SerializeField] Sprite spriteDish;
    [SerializeField] DataDish[] childrentDataDish;

    public string Name { get { return nameDish; } }
    public float TimeCook { get { return timeCook; } }
    public float TimeEat { get { return timeEat; } }
    public bool HasCook { get { return hasCook;} }
    public Sprite ImgDish { get { return spriteDish; } }
    public DataDish[] ChildrentDataDish { get {  return childrentDataDish; } }
}
