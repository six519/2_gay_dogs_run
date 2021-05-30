using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public float BackgroundSpeed = 2;
    public Renderer BackgroundRender;
    public AudioSource BackgroundMusic;
    public GameObject CloudOne;
    public float RespawnTime = 3.0f;
    private Vector2 ScreenBounds;
    void Start()
    {
        BackgroundMusic.Play();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ShowCloud());
    }

    void Update()
    {
        BackgroundRender.material.mainTextureOffset -= new Vector2(BackgroundSpeed * Time.deltaTime, 0f);
    }


    private void SpawnCloudOne()
    {
        GameObject c1 = Instantiate(CloudOne);
        c1.transform.position = new Vector2(-10, Random.Range(-2, 5));
    }


    IEnumerator ShowCloud()
    {
        while(true)
        {
            yield return new WaitForSeconds(RespawnTime);
            SpawnCloudOne();
        }
    }
}
