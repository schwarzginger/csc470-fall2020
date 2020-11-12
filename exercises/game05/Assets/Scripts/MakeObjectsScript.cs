using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeObjectsScript : MonoBehaviour
{
    public GameObject blackpenguinPrefab;
    public GameObject pinkpenguinPrefab;
    public GameObject yellowpenguinPrefab;
    public GameObject bluepenguinPrefab;
    public GameObject purplepenguinPrefab;
    public GameObject greenpenguinPrefab;

    public int numofpenguins;
    public int min, max;


    private void Start()
    {
        PlacePrefabs();
        
    }

    void Update()
    {
      

    }






    public void PlacePrefabs()
    {
        for(int i = 0; i < numofpenguins; i++)
        {
            GameObject newblack = (GameObject)Instantiate(blackpenguinPrefab, GeneratedPos(), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            newblack.tag = "Unit";
    
            GameObject newpink = (GameObject)Instantiate(pinkpenguinPrefab, GeneratedPos(), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            newpink.tag = "Unit";
     
            GameObject newyellow = (GameObject)Instantiate(yellowpenguinPrefab, GeneratedPos(), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            newyellow.tag = "Unit";
    
            GameObject newblue = (GameObject)Instantiate(bluepenguinPrefab, GeneratedPos(), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            newblue.tag = "Unit";
   
            GameObject newpurple = (GameObject)Instantiate(purplepenguinPrefab, GeneratedPos(), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            newpurple.tag = "Unit";
  
            GameObject newgreen = (GameObject)Instantiate(greenpenguinPrefab, GeneratedPos(), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            newgreen.tag = "Unit";
   
        }
    }


    Vector3 GeneratedPos()
    {
        int x, z;
        x = UnityEngine.Random.Range(min, max);
        z = UnityEngine.Random.Range(min, max);
        return new Vector3(x, 0, z); 

    }
}
