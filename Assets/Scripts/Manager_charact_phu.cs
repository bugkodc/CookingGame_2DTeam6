using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager_charact_phu : MonoBehaviour
{
    [Header("move")]
    [SerializeField] public float _speed_move;
    [SerializeField] public GameObject _ways;
    [SerializeField] private Transform[] _waysPos;
    [SerializeField] public float _timewait_move;
    [Header("work")]
    [SerializeField] public float _timewait_work;
    [SerializeField] public float _speed_work;
    [SerializeField] public float _timeload_work;
    [Header("power")]
    [SerializeField] public float _seed_power;
    [SerializeField] public float _power;
    [Header("Level")]
    [SerializeField] public float _level;
    [Header("icon")]
    [SerializeField] public GameObject _icon;
    protected void Move()
    {

    }
    protected void AutoWork()
    {
        
    }
    protected void Power()
    {
       
    }
    protected void Level()
    {

<<<<<<< HEAD

        GetComponent<Rigidbody2D>().velocity = _speed_move * dir;

=======
        //dir.Normalize();
        //animator.SetBool("IsMoving", dir.magnitude > 0);

        //GetComponent<Rigidbody2D>().velocity = _speed_move * dir;
>>>>>>> 137b707 (fix bug)
    }

}
