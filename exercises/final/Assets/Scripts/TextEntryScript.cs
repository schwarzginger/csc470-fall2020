using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class TextEntryScript : MonoBehaviour
{
    public enum MODES { FADING, GAMEPLAY, TEXTBOX };
    public MODES mode;

    public TMP_Text textboxText;
    public GameObject textbox;
    public string[] textEntries;

    public Image fadeImage;
    float fadeRate = 0.7f;
    Coroutine fadeCoroutine;


    void Start()
    {
        mode = MODES.FADING;
        fadeCoroutine = StartCoroutine(fadeIn());
    }


    void Update()
	{

	}


	IEnumerator fadeIn()
	{
		fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
		while (fadeImage.color.a >= 0)
		{
			fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - fadeRate * Time.deltaTime);
			yield return null;
		}

        StartCoroutine(introTextSequence());
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
