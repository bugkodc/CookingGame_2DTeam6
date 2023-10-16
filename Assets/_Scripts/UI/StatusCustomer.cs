using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusCustomer : MonoBehaviour
{
    [SerializeField] Slider slideEating;
    [SerializeField] Slider slideWaiting;
    [SerializeField] Image imgDish;
    [SerializeField] Image imgFeeling;
    Customer customerNow;
    bool hasCustomer;
    public bool HasCustomer { get { return hasCustomer; } }
    public void followCustomer(Customer customer)
    {
        hasCustomer = true;
        customerNow = customer;
    }
    private void Update()
    {
        if(customerNow != null)
        {
            transform.position = customerNow.transform.position;
        }
    }
    public void Order(Image img)
    {
        imgDish.gameObject.SetActive(true);
        imgDish.sprite = img.sprite;
        Debug.Log("a");
        OnWaiting();
    }
    public void OnWaiting()
    {
        slideWaiting.gameObject.SetActive(true);
    }
    public void OnEating()
    {
        imgDish.gameObject.SetActive(false);
        slideEating.gameObject.SetActive(true);
        slideWaiting.gameObject.SetActive(false);
    }
    public void UpdateSliderWaiting(float count)
    {
        slideWaiting.value = count;
    }
    public void UpdateSliderEating(float count)
    {
        slideEating.value = count;
    }
    
    public void StandUp()
    {
        slideEating.gameObject.SetActive(false);
        imgDish.gameObject.SetActive(false);
        imgFeeling.gameObject.SetActive(true);
    }
    public void OutRestaurant()
    {
        slideEating.value = 1;
        slideEating.gameObject.SetActive(false);
        slideWaiting.value = 1;
        slideWaiting.gameObject.SetActive(false);
        imgDish.sprite = null;
        imgDish.gameObject.SetActive(false);
        //imgFeeling.sprite = null;
        imgFeeling.gameObject.SetActive(false);
        hasCustomer = false;
        customerNow = null;
    }
}
