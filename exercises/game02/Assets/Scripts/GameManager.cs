using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject firePrefab;
    GameObject ground;
    public GameObject diamond;

    float makediamondTimer = 0.2f;
    float makediamondRate = 0.2f;

    int numFireBalls = 0; 

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Ground"); 
    }

    // Update is called once per frame
    void Update()
    {

        makediamondTimer -= Time.deltaTime;
        if (makediamondTimer < 0)
        {
            // If we get in here, it means that makeRainRate amount of time has gone by.

            // Create a position to spawn the rainDrop.
            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-20, 20)
                                , ground.transform.position.y + 50,
                                ground.transform.position.z + Random.Range(-20, 20));
            // Instantiate the rainDrop prefab and store a reference to it in 'drop'.
            GameObject diamondobject = Instantiate(diamond, pos, Quaternion.identity);
            // Get the 'renderer' component from drop, and assign a random color to its material.
            Renderer rend = diamondobject.GetComponent<Renderer>();
            rend.material.color = new Color(Random.value, Random.value, Random.value);

            // Tell Unity to destroy drop in 5 seconds.
            Destroy(diamondobject, 5f);

            // Reset the timer so that in makeRainRate amount of time we will go into this
            // if statement again.
            makediamondTimer = makediamondRate;




        }

    }

    public void dropFireBalls()
    {

        numFireBalls++;

        if (numFireBalls < 10)
        {
            Debug.Log("Drop Fire Balls");
            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-15, 15),
                ground.transform.position.y + 15,
                ground.transform.position.z + Random.Range(-15, 15));
            Instantiate(firePrefab, pos, Quaternion.identity);
        }

        else
        {
            // Load Level

            SceneManager.LoadScene("NewLevel"); 

        }

    }
}
