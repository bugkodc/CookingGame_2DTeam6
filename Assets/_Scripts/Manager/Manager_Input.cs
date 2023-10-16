using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Input : MonoBehaviour
{
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 _InputVector = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.A))
        {
            _InputVector.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _InputVector.x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            _InputVector.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _InputVector.y = -1;
        }
        _InputVector = _InputVector.normalized;
        return _InputVector;
    }
}
