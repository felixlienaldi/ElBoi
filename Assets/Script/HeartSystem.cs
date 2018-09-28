using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour {

    private int maxHeart = 10;
    public int startHeart = 3;
    public int currHealth;
    public int maxHealth;
    public int healthperHeart = 2;

    public Image[] HeartImage;
    public Sprite[] HeartSprite;
    public DeathManager death;
    // Use this for initialization
    void Start()
    {
        currHealth = startHeart * healthperHeart;
        maxHealth = maxHeart * healthperHeart;
        checkHealth();
    }

    public void checkHealth()
    {
        for (int i = 0; i < maxHeart; i++)
        {
            if (startHeart <= i)
            {
                HeartImage[i].enabled = false;
            }
            else
            {
                HeartImage[i].enabled = true;
            }
        }
        updateHearts();

    }

    public void updateHearts() {
        bool empty = false;
        int i = 0;

        foreach (Image image in HeartImage)
            if (empty)
            {
                image.sprite = HeartSprite[0];
            }
            else
            {
                i++;
                if (currHealth >= i * healthperHeart)
                {
                    image.sprite = HeartSprite[HeartSprite.Length - 1];
                }
                else {
                    int currenthearthealth = (int)(healthperHeart - (healthperHeart * i - currHealth));
                    int healthperimage = healthperHeart / (HeartSprite.Length - 1);
                    int imageindex = currenthearthealth / healthperimage;
                    image.sprite = HeartSprite[imageindex];
                    empty = true;
                }
            }
        }


    public void takedamage(int damage) {
        Debug.Log("tesss");
        currHealth -= damage;
        currHealth = Mathf.Clamp(currHealth,0,healthperHeart*startHeart);
        checkHealth();
        updateHearts();
        if(currHealth <=0)
        {
            Debug.Log("tess");
            death.Death();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
