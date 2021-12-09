using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour

{
    private void Awake()
    {



        DontDestroyOnLoad(this.gameObject);

    }

    
    public int maxHealth = 100;
    public int health = 100;

    public int xp = 0;
    public int lv = 1;
    public int xpToNextLv = 100;

    public int attack = 20;
    public int healthPotions = 3;



    public void ChangeHealth(int change)
    {
        health += change;

        if (health > maxHealth)
            health = maxHealth;//can't overheal

        if (health <= 0)
            Debug.Log(name + " Died");
    }
    public void updateXp(int newXP)
    {
        xp += newXP;
        if (xp >= xpToNextLv)
        {
            xp = 0;
            xpToNextLv += 50;
            lv += 1;
            attack += Random.Range(15, 25);
            maxHealth += Random.Range(35, 65);
            health = maxHealth;
        }
    }
}
