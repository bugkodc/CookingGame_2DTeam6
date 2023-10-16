using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlTray : MonoBehaviour
{
    [SerializeField] int countBowl = 0;
    public int CountBowl { get { return countBowl; } }
    [SerializeField] int maxBowl;
    public int MaxBowl { get { return maxBowl; } }

    public void AddBowl()
    {
        countBowl++;
        if(countBowl >= maxBowl)
        {
            countBowl = maxBowl;
        }
    }
    public void TakeBowl()
    {
        countBowl--;
        if(countBowl <= 0)
        {
            countBowl = 0;
        }
    }
}
