using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public float BackgroundSpeed = 2;
    public Renderer BackgroundRender;
    public AudioSource BackgroundMusic;
    public GameObject CloudOne;
    public GameObject CloudTwo;
    public GameObject CloudThree;
    public float RespawnTimeCloudOne = 3.0f;
    public float RespawnTimeCloudTwo = 2.5f;
    public float RespawnTimeCloudThree = 5.0f;
    private Vector2 ScreenBounds;
    private TextMesh ScoreTextMesh;
    void Start()
    {
        BackgroundMusic.Play();
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        ScoreTextMesh = GameObject.Find("Score").GetComponent<TextMesh>();
        StartCoroutine(ShowCloudOne());
        StartCoroutine(ShowCloudTwo());
        StartCoroutine(ShowCloudThree());
    }

    void Update()
    {
        BackgroundRender.material.mainTextureOffset -= new Vector2(BackgroundSpeed * Time.deltaTime, 0f);
        //Show score
        ScoreTextMesh.text = "Score:" + GlobalVariableScript.GameScore;
    }


    private void SpawnCloudOne()
    {
        GameObject c1 = Instantiate(CloudOne);
        c1.transform.position = new Vector2(-10, Random.Range(-2, 5));
    }

    private void SpawnCloudTwo()
    {
        GameObject c2 = Instantiate(CloudTwo);
        c2.transform.position = new Vector2(-10, Random.Range(-2, 5));
    }

    private void SpawnCloudThree()
    {
        GameObject c3 = Instantiate(CloudThree);
        c3.transform.position = new Vector2(-10, Random.Range(-2, 5));
    }

    IEnumerator ShowCloudOne()
    {
        while(true)
        {
            yield return new WaitForSeconds(RespawnTimeCloudOne);
            SpawnCloudOne();
        }
    }

    IEnumerator ShowCloudTwo()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTimeCloudTwo);
            SpawnCloudTwo();
        }
    }

    IEnumerator ShowCloudThree()
    {
        while (true)
        {
            yield return new WaitForSeconds(RespawnTimeCloudThree);
            SpawnCloudThree();
        }
    }
}
