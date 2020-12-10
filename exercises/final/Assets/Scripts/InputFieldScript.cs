using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class InputFieldScript : MonoBehaviour
{
    public InputField inputfield;

    public void CheckInput()
    {
        if (inputfield.text == "ONCEANEAGLEALWAYSANEAGLE")      // check inputfield contains the string password
        {
            Debug.Log("Password accepted");     // just a debug.Log to show that the password is correct (can be removed)
            SceneManager.LoadScene("PuzzleScene");  // fill in the name of the scene you want to load
        }
    }
}
