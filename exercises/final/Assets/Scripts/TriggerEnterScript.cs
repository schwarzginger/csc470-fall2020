using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TriggerEnterScript : MonoBehaviour
{

    public enum MODES { FADING, GAMEPLAY, TEXTBOX };
    public MODES mode;

    public TMP_Text textboxText;
    public GameObject textbox;
    public string[] textEntries;

    public void Start()
    {
        mode = MODES.FADING;
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            StartCoroutine(introTextSequence());

        }

    }

    IEnumerator introTextSequence()
    {
        mode = MODES.TEXTBOX;

        textbox.SetActive(true);
        textboxText.text = textEntries[0];
        int count = 0;
        while (count < textEntries.Length)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                count++;
                if (count < textEntries.Length)
                {
                    textboxText.text = textEntries[count];
                }
            }
            yield return null;
        }
        textbox.SetActive(false);

        mode = MODES.GAMEPLAY;
    }


}
