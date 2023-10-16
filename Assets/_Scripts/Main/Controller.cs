using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private Manager_Input _Input;
    [Header("Move")]
    public float _speed;
    private void Update()
    {
        Move();
    }
    #region Move
    private void Move()
    {
        Vector2 _InputVector = _Input.GetMovementVectorNormalized();
        GetComponent<Rigidbody2D>().velocity = _speed * _InputVector;
    }
    #endregion
}
