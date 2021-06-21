using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        GlobalVariableScript.GameScore = 0;
        GlobalVariableScript.GameLives = 3;
        SceneManager.LoadScene("CharacterSelectionScene");
    }
}
