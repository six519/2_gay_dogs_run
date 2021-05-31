using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int CharacterSelection = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GlobalVariableScript.SelectedCharacter = CharacterSelection;
        SceneManager.LoadScene("GameScene");
    }
}
