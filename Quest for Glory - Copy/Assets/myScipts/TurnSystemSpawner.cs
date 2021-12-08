using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystemSpawner : MonoBehaviour
{
    public GameObject spwan;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("TurnSystem") == null)
        {
            GameObject newObject = Instantiate(spwan);
        }
    }
    
}
    

   
    
