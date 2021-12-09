using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor.FantasyInventory.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TurnBased : MonoBehaviour
{
    public playerStats Player;
    public GameObject playerBody;
    public GameObject enemyBody;
    public Slider playerHealthBar, enemyHeakthBar;
    public enemy enemy;
    public float sliderSpeed = .01f;
    public Button attkBtn, runBtn, potionBtn;
    public bool playerTurn = true;
    public Animator enem, play;

    private void Start()
    {
        Player = GameObject.Find("PS").GetComponent<playerStats>();
        playerHealthBar.value = (float)Player.health / Player.maxHealth;

        enemyHeakthBar.value = (float)enemy.health / enemy.maxHealth;

        enem = enemyBody.GetComponent<Animator>();
        play = playerBody.GetComponentInChildren<Animator>();

    }  
    public void FixedUpdate()
    {
        /*
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("encounter")){ 
           

        }
        */
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
        enem.Play("Attack");
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
        play.Play("Attack");
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
