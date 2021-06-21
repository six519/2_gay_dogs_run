using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public float Speed = 2f;
    private Rigidbody2D ThisRigidBody;
    private Vector2 ScreenBounds;
    public AudioSource GrabSound;

    void Start()
    {

        if (GlobalVariableScript.SelectedCharacter == 0)
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load("apple_resize", typeof(Sprite)) as Sprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load("money", typeof(Sprite)) as Sprite;
        }

        ThisRigidBody = this.GetComponent<Rigidbody2D>();
        ThisRigidBody.velocity = new Vector2(Speed, 0);
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
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
            GrabSound.Play();
            GlobalVariableScript.GameScore += 5;
            while (!GrabSound.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
