using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;



public class controller : MonoBehaviour
{
    
    int i = 0;
   // public bool inTown = false;
    private Vector2 movemtnInput;
    private Vector3 total;
    private Vector3 direction;
    private Animator anim;

    /*
  
    private Vector3 tempVect;
    private Vector3Int currentLocation;
    public Tilemap map;
    private TileBase currentTile;
   public TileBase town1;
    public TileBase town2;
    public TileBase city;

    public TileBase plains;
    public TileBase woods;
    public TileBase hills;
    */
    bool hasMoved;
    bool moving=false;

    public int Min=0,max=15;

    public int maxSafeDIstance=2,minRanEncoterDistance=3,maxRanEncoterDistance=5,MaxDistanceTillEncoter=6;
    private void Start()
    {
        Debug.Log("start");
        total = transform.position;
        anim = GetComponentInChildren<Animator>();
        Debug.Log("pass");
    }

    private void FixedUpdate()
    {
        /*     // to get tile player is on was not working correctly  
          tempVect=( this.gameObject.transform.position);
          currentLocation.x = (Mathf.FloorToInt(tempVect.x));
          currentLocation.y = (Mathf.FloorToInt(tempVect.y));
          currentLocation.z = 0;
          currentTile = map.GetTile(currentLocation);
          Debug.Log(currentTile);


          if(currentTile==town1 || currentTile == town2 || currentTile == city)
          {
              inTown = true;
          }

          else { inTown = false; }
        */
         movemtnInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (movemtnInput.x == 0)
            {

                hasMoved = false;
            Debug.Log("falso");

            }
            else if (movemtnInput.x != 0 && !hasMoved && moving==false)
            {
            Debug.Log("ture1");
         //   if (inTown == false) { 
            Enconter();
        //   }

                hasMoved = true;
                GetMovemtnDirection();
            Debug.Log("ture2");

            }

          moving = true;
            transform.position = Vector3.MoveTowards(transform.position, total, 1 * Time.deltaTime);
            if (transform.position == total) {moving = false; }

            if (moving == true) { anim.SetBool("moving", true); }
            else if (moving == false) { anim.SetBool("moving", false); }
       


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
            if (transform.localScale.x > 0) { transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); }

            total = transform.position + direction;

           

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
            if (transform.localScale.x < 0) { transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); }

            total = transform.position + direction;

        }


    }
    public void Enconter()
    {
        if (maxSafeDIstance >= i) { i++; }
        else if (i >= 3 && i <= 5)
        {
            int j = Random.Range(Min, max);
            i++;


            if (j == 1)
            {
                Debug.Log("enconter! randome encoter");
                SceneManager.LoadScene("Encounter");

            }
        }
        else if (i >= 6)
        {
            i = 0;
            Debug.Log("enconter! Hit max distance with out encoter");
            SceneManager.LoadScene("Encounter");

        }



    }
    


}


