using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_Key : MonoBehaviour
{
    [SerializeField] private Transform _TransformMain;
    void Start()
    {
        transform.position = new Vector2(_TransformMain.position.x + 1.8f, _TransformMain.position.y + 2.4f);  
    }       
}
