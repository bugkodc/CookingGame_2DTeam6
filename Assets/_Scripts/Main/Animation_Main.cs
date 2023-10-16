using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Main : MonoBehaviour
{
    private Animator _Animator;
    [SerializeField] private Manager_Input _Input;
    private void Start()
    {
        _Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_Input.GetMovementVectorNormalized().x == -1 ) _Animator.SetInteger("Direction", 3);//A
        if (_Input.GetMovementVectorNormalized().x == 1) _Animator.SetInteger("Direction", 2);//D
        if (_Input.GetMovementVectorNormalized().y == 1) _Animator.SetInteger("Direction", 1);//W
        if (_Input.GetMovementVectorNormalized().y == -1) _Animator.SetInteger("Direction", 0);//S
        _Animator.SetBool("IsMoving", _Input.GetMovementVectorNormalized().magnitude > 0);

    }

}
