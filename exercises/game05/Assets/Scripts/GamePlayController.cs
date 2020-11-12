using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameChoices
{
    NONE,
    FIRE,
    WATER,
    WIND
}

public class GamePlayController : MonoBehaviour
{

    [SerializeField]
    private Sprite fire_Sprite, water_Sprite, wind_Sprite;


    [SerializeField]
    private Image playerChoice_img, opponentChoice_img;

    [SerializeField]
    private Text infoText;

    private GameChoices player_Choices = GameChoices.NONE, opponent_Choice = GameChoices.NONE;


    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>(); 
    }

    public void SetChoices(GameChoices gameChoices) {

        switch (gameChoices)
        {
            case GameChoices.FIRE:

                playerChoice_img.sprite = fire_Sprite;
                player_Choices = GameChoices.FIRE; 
                break;

            case GameChoices.WATER:
                playerChoice_img.sprite = water_Sprite;
                player_Choices = GameChoices.WATER;

                break;

            case GameChoices.WIND:
                playerChoice_img.sprite = wind_Sprite;
                player_Choices = GameChoices.WIND;

                break;
        }

        SetOpponentChoice();

        DetermineWinner(); 
    }


    void SetOpponentChoice()
    {
        int rnd = Random.Range(0, 3);

        switch (rnd)
        {
            case 0:

                opponent_Choice = GameChoices.FIRE;
                opponentChoice_img.sprite = fire_Sprite; 
                break;

            case 1:
                opponent_Choice = GameChoices.WATER;
                opponentChoice_img.sprite = water_Sprite;
                break;

            case 2:
                opponent_Choice = GameChoices.WIND;
                opponentChoice_img.sprite = wind_Sprite;
                break;
        }
    }

    void DetermineWinner()
    {
        if(player_Choices == opponent_Choice)
        {
            //draw
            infoText.text = "It's a Draw";
            StartCoroutine(DisplayWinnerandRestart());

            return; 
        }

        if(player_Choices == GameChoices.FIRE && opponent_Choice == GameChoices.WIND)
            
        {
            //player wins
            infoText.text = "You Win";
            StartCoroutine(DisplayWinnerandRestart());

            return;
        }

        if (opponent_Choice == GameChoices.FIRE && player_Choices == GameChoices.WIND)

        {
            //opponent wins
            infoText.text = "You Lose";
            StartCoroutine(DisplayWinnerandRestart());

            return;
        }


        if (player_Choices == GameChoices.WATER && opponent_Choice == GameChoices.FIRE)

        {
            //player wins
            infoText.text = "You Win";
            StartCoroutine(DisplayWinnerandRestart());

            return;
        }

        if (opponent_Choice == GameChoices.WATER && player_Choices == GameChoices.FIRE)

        {
            //opponent wins
            infoText.text = "You Lose";
            StartCoroutine(DisplayWinnerandRestart());

            return;
        }

        if (player_Choices == GameChoices.WIND && opponent_Choice == GameChoices.WATER)

        {
            //player wins
            infoText.text = "You Win";
            StartCoroutine(DisplayWinnerandRestart());

            return;
        }


        if (opponent_Choice == GameChoices.WIND && player_Choices == GameChoices.WATER)

        {
            //opponent wins
            infoText.text = "You Lose";
            StartCoroutine(DisplayWinnerandRestart());

            return;
        }
    }

    IEnumerator DisplayWinnerandRestart()
    {
        yield return new WaitForSeconds(2f);

        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        infoText.gameObject.SetActive(false);

        animationController.ResetAnimations(); 
    }
}
