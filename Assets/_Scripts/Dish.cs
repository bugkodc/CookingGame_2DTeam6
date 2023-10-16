using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    [SerializeField] DataDish dataDish;
    SpriteRenderer spriteRenderer;
    public DataDish DataDish { get { return dataDish; } }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        setSprite();
    }
    void setSprite()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = DataDish.SpriteDish;
        }
    }
}
