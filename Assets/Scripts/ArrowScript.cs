using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowScript : MonoBehaviour
{
    public float Speed = 9f;
    private Rigidbody2D ThisRigidBody;
    private Vector2 ScreenBounds;
    private float PrevAddSpeed;
    public AudioSource AwSound;
    private float additionalSpeed = 3f;

    void Start()
    {
        PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
        ThisRigidBody = this.GetComponent<Rigidbody2D>();

        ThisRigidBody.velocity = new Vector2(Speed + PrevAddSpeed + (GlobalVariableScript.GlobMultiplier * additionalSpeed), 0);

        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (PrevAddSpeed != GlobalVariableScript.AdditionalSpeed)
        {
            PrevAddSpeed = GlobalVariableScript.AdditionalSpeed;
            ThisRigidBody.velocity = new Vector2(Speed + PrevAddSpeed + (GlobalVariableScript.GlobMultiplier * additionalSpeed), 0);
        }

        if (transform.position.x > ScreenBounds.x * 1.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BIDA")
        {
            this.gameObject.transform.position = new Vector2(-10, 6); //move the object outside the screen
            AwSound.Play();
            GlobalVariableScript.GameLives -= 1;


            if (GlobalVariableScript.GameLives == 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            ControllerScript cs = GameObject.Find("Controller").GetComponent<ControllerScript>();
            cs.UpdateHearts();

            while (!AwSound.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
