using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleTriggerScript : MonoBehaviour
{

    public GameObject player; 

    private void Update()
    {
        if (player.transform.position == new Vector3(-2, 0, 0))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }


}
