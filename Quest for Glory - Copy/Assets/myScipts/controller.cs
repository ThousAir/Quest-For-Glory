using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class controller : MonoBehaviour
{
    
    int i = 0;
    public bool inBattle = false;
    private Vector2 movemtnInput;
    
    private Vector3 direction;

    bool hasMoved;
    public int Min=0,max=15;
   
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (inBattle == false)
        {

            movemtnInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (movemtnInput.x == 0)
            {

                hasMoved = false;


            }
            else if (movemtnInput.x != 0 && !hasMoved)
            {
                Enconter();
                hasMoved = true;
                GetMovemtnDirection();

            }

        }

    }
    public void GetMovemtnDirection()
    {
        if (movemtnInput.x < 0)
        {
            if (movemtnInput.y > 0)
            {
                direction = new Vector3(-1.28f, 2f);
            }
            else if (movemtnInput.y < 0)
            {
                direction = new Vector3(-1.28f, -2f);
            }
            else { direction = new Vector3(-2.56f, 0, 0); }

            transform.position += direction;


        }
        else if (movemtnInput.x > 0)
        {
            if (movemtnInput.y > 0)
            {
                direction = new Vector3(1.28f, 2f);
            }
            else if (movemtnInput.y < 0)
            {
                direction = new Vector3(1.28f, -2f);
            }
            else { direction = new Vector3(2.56f, 0, 0); }

            transform.position += direction;

        }


    }
    public void Enconter()
    {
        Debug.Log(i);
        int j = Random.Range(Min, max);
        Debug.Log(j);
        if (j == 1)
        {
            Debug.Log("enconter! 1 ");
            SceneManager.LoadScene("Encounter");

        }
        i++;
    }
    


}


