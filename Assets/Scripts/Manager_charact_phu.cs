using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager_charact_phu : MonoBehaviour
{
    [Header("move")]
    [SerializeField] public float _speed_move;
    [SerializeField] public GameObject _ways;
    [SerializeField] public float _timewait_move;
    [Header("work")]
    [SerializeField] public float _timewait_work;
    [SerializeField] public float _speed_work;

    [Header("power")]
    [SerializeField] public float _seed_power;
    [SerializeField] public float _power;
    [Header("icon")]
    [SerializeField] public GameObject _icon;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected void Move()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = _speed_move * dir;
    }

}
