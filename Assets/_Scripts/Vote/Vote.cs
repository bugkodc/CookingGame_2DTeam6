using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelVoting
{
    [SerializeField] int star;
    [SerializeField] int expReceive;
    [SerializeField] float time;

    public int Star => star;
    public int ExpReceive => expReceive;
    public float Time => time;
}
public class Vote : MonoBehaviour
{
    public LevelVoting[] listVote;
    public ExpEvaluate evaluate;
    private void Start()
    {
        if(evaluate == null)
        {
            evaluate = FindObjectOfType<ExpEvaluate>();
        }
    }
    public void VoteRestaurant(float timeWait)
    {
        foreach (LevelVoting vote in listVote)
        {
            if(timeWait < vote.Time)
            {
                evaluate.AddStar(vote.Star);
                return;
            }
        }
    }
    public void VoteRestaurant(int star)
    {
        evaluate.AddStar(star);
    }
}
