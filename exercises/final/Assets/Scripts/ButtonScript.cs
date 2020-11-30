using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void MoveToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MoveToInstructionScene()
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    public void MoveToSelectionScene()
    {
        SceneManager.LoadScene("SelectionScene");
    }

    public void MoveToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
