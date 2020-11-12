using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
    public void GotoTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToInstructionsScene()
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    public void GotoPickPlayerScene()
    {
        SceneManager.LoadScene("PickPlayerScene");
    }
}
