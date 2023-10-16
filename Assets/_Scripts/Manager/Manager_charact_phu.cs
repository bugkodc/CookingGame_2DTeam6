using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_charact : MonoBehaviour
{
    [Header("move")]
    [Range(0f, 10f)]
    public float _speed;
    private Vector3 _tagetPos;
    [SerializeField] private GameObject _ways;
    [SerializeField] private Transform[] _waysPos;
    int _PosIndex;
    int _PosCount;
    int _direction = 1;
    int _speedMultipler = 1;
    [Header("work")]
    [Range(0, 3)]
    [SerializeField] public float _timewait_work;
    [SerializeField] public float _speed_work;
    [SerializeField] public float _timeload_work;
    [SerializeField] public GameObject _Menu;
    [Header("power")]
    [SerializeField] public float _seed_power;
    [SerializeField] public float _power;
    [Header("Level")]
    [SerializeField] public float _level;
    [Header("icon")]
    [SerializeField] public GameObject _icon;
    private void Awake()
    {
        _waysPos = new Transform[_ways.transform.childCount];
        for (int i = 0; i < _ways.gameObject.transform.childCount; i++)
        {
            _waysPos[i] = _ways.transform.GetChild(i).gameObject.transform;
        }
    }
    private void Start()
    {
        _PosCount = _waysPos.Length;
        _PosIndex = 0;
        _tagetPos = _waysPos[_PosIndex].transform.position;
    }
    private void Update()
    {
        var step = _speedMultipler * _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _tagetPos, step);
        if (transform.position == _tagetPos)
        {
            NextPoint();
        }
    }
    #region Moving
    void NextPoint()
    {
        if (_PosIndex == 0 || _PosIndex == (_PosCount - 1))
        {
            StartCoroutine(waitNextPoint());
        }
        if (_PosIndex == _PosCount - 1)
        {
            _direction = -1;
        }
        if (_PosIndex == 0)
        {
            _direction = 1;
        }
        _PosIndex += _direction;
        _tagetPos = _waysPos[_PosIndex].transform.position;
    }
    IEnumerator waitNextPoint()
    {
        _speedMultipler = 0;
        yield return new WaitForSeconds(_timewait_work);
        _speedMultipler = 1;
    }
    #endregion
    protected void AutoWork()
    {
        
    }
    protected void Power()
    {
       
    }
    protected void Level()
    {


    }

}
