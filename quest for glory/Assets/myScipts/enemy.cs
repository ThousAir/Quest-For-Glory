using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemy : MonoBehaviour
{

    public int maxHealth = 100;
    public int health = 100;

    public int attack = 20;
   public int level = 1;
    public void ChangeHealth(int change)
    {

        health += change;

        if (health > maxHealth)
            health = maxHealth;//can't overheal

        if (health <= 0)
            Debug.Log(name + " Died");
    }

    public void ChangeAttack(int at)
    {
        attack = at;
    }
}
