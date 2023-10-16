using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ExpEvaluate : MonoBehaviour
{
    TextMeshProUGUI reputation;
    List<int> listStarExp;
    float starNow;
    private void Start()
    {
        reputation = GetComponent<TextMeshProUGUI>();
        listStarExp = new List<int>();
        ShowStar();
    }
    public void AddStar(int star)
    {
        listStarExp.Add(star);
        Debug.Log("vote: " + star + " sao");
        starNow = CalculateStar();
        ShowStar();
    }
    float CalculateStar()
    {
        if (listStarExp.Count == 0)
        {
            // Tránh trường hợp chia cho 0
            return 0.0f;
        }
        float tong = listStarExp.Sum();
        float trungBinh = tong / listStarExp.Count;
        return (float)Math.Round(trungBinh, 1);
    }
    void ShowStar()
    {
        reputation.text = starNow.ToString() + " sao";
    }
}
