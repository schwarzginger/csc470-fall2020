using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceTrigger : MonoBehaviour
{
    public GameObject diamondPrefab;
    public GameObject pumpkinPrefab; 
    GameObject ground;
    // Use this for initialization
    void Start()
    {
        ground = GameObject.Find("Ground");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < 100; i++)
            {
                Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-50, 50), ground.transform.position.y + Random.Range(5,50), ground.transform.position.z + Random.Range(-50, 50));
                GameObject diamond = Instantiate(diamondPrefab, pos, Quaternion.identity);
            }

            for (int i = 0; i < 40; i++)
            {
                Vector3 pos2 = new Vector3(ground.transform.position.x + Random.Range(-50, 50), ground.transform.position.y + Random.Range(10, 50), ground.transform.position.z + Random.Range(-50, 50));
                GameObject babypumpkin = Instantiate(pumpkinPrefab, pos2, Quaternion.identity);
                babypumpkin.transform.Rotate(0, Random.Range(0, 360), 0);
            }
        }
    }
}