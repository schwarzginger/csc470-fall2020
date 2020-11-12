using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    private AnimationController animationController;
    private GamePlayController gameplayController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        gameplayController = GetComponent<GamePlayController>();

    }

    public void GetChoice()
    {
        string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        GameChoices selectedChoice = GameChoices.NONE;

        switch (choiceName)
        {
            case "Fire":
                selectedChoice = GameChoices.FIRE; 
                break;

            case "Water":
                selectedChoice = GameChoices.WATER;
                break;

            case "Wind":
                selectedChoice = GameChoices.WIND;
                break;
        }

        gameplayController.SetChoices(selectedChoice);
        animationController.PlayerMadeChoice(); 
    }
}
