using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class Customer : MonoBehaviour
{
    [SerializeField] UICharacter uiCharacter;
    [SerializeField] DinnerTable dinnerTable;
    //[SerializeField] SpriteRenderer spriteDishOrder;
    //Thời gian chờ món ăn
    float timeWait;
    float countTimeWait = 0;

    //Thời gian ăn món ăn đó
    float timeEat;
    float countTimeEat = 0;

    [SerializeField] float moveSpeed = 5;

    //Có món ăn chưa ?
    bool hasFood = false;
    bool isMoving = false;

    //Món ăn order
    DataDish orderFood;
    StatusCustomer statusCustomer;
    ComboTableChair comboTableChair;

    private void OnEnable()
    {
        if(dinnerTable==null)
        dinnerTable = FindObjectOfType<DinnerTable>();
        if(uiCharacter==null)
        uiCharacter = FindObjectOfType<UICharacter>();
        EnterRestaurant();
    }
    void EnterRestaurant()
    {
        FindTable();
    }
    void FindTable()
    {
        if(dinnerTable.CheckEmptyTable() == true)
        {
            comboTableChair = dinnerTable.GetEmptyTable();
            comboTableChair.customerNow = this;
            comboTableChair.getChair.CustomerSitDown();
        }
        SetUpUiStatus();
        if (!isMoving)
        {
            Vector3 chairEmpty = comboTableChair.getChair.gameObject.transform.position;
            StartCoroutine(GoingtoTableCoroutine(chairEmpty));
        }
    }
    void SetUpUiStatus()
    {
        statusCustomer = uiCharacter.getUIStatus();
        statusCustomer.followCustomer(this);
    }
    private IEnumerator GoingtoTableCoroutine(Vector3 targetPosition)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
        SitDown();
    }
    void SitDown()
    {
        hasFood = false;
        timeWait = UnityEngine.Random.Range(20f, 30f);
        ThinkOrder();
    }
    void ThinkOrder()
    {
        int countMenuDish = dinnerTable.menu.MenuDish.Count;
        if (countMenuDish == 0)
        {
            Debug.LogWarning("MenuDish list is empty. Cannot select a random dish.");
            return ;
        }

        int randomIndex = UnityEngine.Random.Range(0, countMenuDish);
        DataDish randomDish = dinnerTable.menu.MenuDish[randomIndex];

        orderFood = randomDish;
        Order();
    }
    void Order()
    {
        timeEat = orderFood.TimeEat;
        statusCustomer.Order(orderFood.ImgDish);
        comboTableChair.getTable.SetOrderFoodCustomer(orderFood);
        statusCustomer.OnWaiting();
        StartCoroutine(WaitingCoroutine());
    }
    IEnumerator WaitingCoroutine()
    {
        if (timeWait == 0) yield break;

        while (!hasFood)
        {
            countTimeWait += Time.deltaTime;
            statusCustomer.UpdateSliderWaiting(1 - countTimeWait / timeWait);
            if (countTimeWait >= timeWait)
            {
                VoteZeroStar();
                StandUp();
                yield break; // Kết thúc coroutine sau khi gọi StandUp
            }
            yield return null; // Chờ một frame trước khi kiểm tra lại
        }
    }
    public void StartEat()
    {
        hasFood = true;
        //spriteDishOrder.sprite = null;
        statusCustomer.OnEating();
        StartCoroutine(EatingCoroutine());
    }
    IEnumerator EatingCoroutine()
    {
        if (timeEat == 0)
        {
            yield break; // Kết thúc coroutine nếu thời gian ăn là 0
        }

        while (hasFood)
        {
            countTimeEat += Time.deltaTime;
            statusCustomer.UpdateSliderEating(countTimeEat / timeEat);
            if (countTimeEat >= timeEat)
            {
                FinishEat();
                yield break; // Kết thúc coroutine sau khi gọi FinishEat
            }
            yield return null; // Chờ một frame trước khi kiểm tra lại
        }
    }
    public void FinishEat()
    {
        hasFood = false;
        Evalute();

        StandUp();
    }
    void StandUp()
    {
        comboTableChair.getChair.CustomerStandUp();
        comboTableChair.getTable.CleanTable();
        statusCustomer.StandUp();

        //Setup lại thời gian
        countTimeWait = 0;
        countTimeEat = 0;
        timeWait = 0;
        timeEat = 0;
        comboTableChair = null;
        StartCoroutine(GoingOutCoroutine(dinnerTable.doorOut.transform.position));
    }
    private IEnumerator GoingOutCoroutine(Vector3 targetPosition)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
        OutRestaurant();
    }
    void OutRestaurant()
    {
        statusCustomer.OutRestaurant();
        gameObject.SetActive(false);
    }
    void Evalute()
    {
        VoteService();
    }
    void VoteService()
    {
        dinnerTable.vote.VoteRestaurant(countTimeWait);
    }
    void VoteZeroStar()
    {
        dinnerTable.vote.VoteRestaurant(0);
    }
    void PayForFood()
    {

    }
}
