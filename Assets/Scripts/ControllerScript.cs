using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public float BackgroundSpeed = 2;
    public Renderer BackgroundRender;
    public AudioSource BackgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundRender.material.mainTextureOffset -= new Vector2(BackgroundSpeed * Time.deltaTime, 0f);
    }
}
