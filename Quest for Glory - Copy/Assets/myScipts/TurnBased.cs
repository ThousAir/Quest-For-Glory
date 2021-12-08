using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor.FantasyInventory.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TurnBased : MonoBehaviour
{
    public playerStats Player;
    void Awake()
    {Player = GameObject.Find("PS").GetComponent<playerStats>(); }
    

    public Slider playerHealthBar, enemyHeakthBar;
    public enemy enemy;
    public float sliderSpeed = .01f;
    public Button attkBtn, runBtn, potionBtn;
    public bool playerTurn = true;


    private void Start()
    {
        playerHealthBar.value = (float)Player.health / Player.maxHealth;

        enemyHeakthBar.value = (float)enemy.health / enemy.maxHealth;

    }  
    public void FixedUpdate()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("encounter")){ 
           

        }
    }

    public void SwitchTurn()
    {
        playerTurn = !playerTurn;
        if (!playerTurn)
        {
            attkBtn.interactable =
            runBtn.interactable =
            runBtn.interactable =false;
            EnemyTurn();
        }
        else
        {
            attkBtn.interactable =
            runBtn.interactable =
            runBtn.interactable = true;
            
        }

    }

    public void EnemyTurn()
    {
            Player.ChangeHealth(-enemy.attack);
            playerHealthBar.value = (float)Player.health / Player.maxHealth;

            if (Player.health <= 0)
            {
                SceneManager.LoadScene("Main Menu");
            }

            SwitchTurn();
        

    }
   
    public void ATTACK()
    {
        enemy.ChangeHealth(-Player.attack);
        enemyHeakthBar.value = (float)enemy.health / enemy.maxHealth;
        if (enemy.health <= 0)
        {
            Player.updateXp(20 * enemy.level);
            SceneManager.LoadScene("Map");
            Destroy(this.gameObject);
        }

        SwitchTurn();
    }
    public void Heal()
    {
        Player.healthPotions--;
        Player.ChangeHealth(30);
        playerHealthBar.value = (float)Player.health / Player.maxHealth;

    }
    public void run()
    {
        if (Random.Range(1, 5) == 1)
        {
            SwitchTurn();
        }
        else
        {
            SceneManager.LoadScene("map");
        }
    }
    
}
