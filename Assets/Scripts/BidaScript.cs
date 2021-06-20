using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidaScript : MonoBehaviour
{
    private Animator thisAnimator;
    private Rigidbody2D rb;
    public AudioSource BarkSound;
    private float previousAnimSpeed;
    private bool canJump = true;
    void Start()
    {
        thisAnimator = this.GetComponent<Animator>();
        previousAnimSpeed = thisAnimator.speed;
        rb = this.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(GameObject.Find("close").GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        if (GlobalVariableScript.SelectedCharacter == 0)
        {
            thisAnimator.runtimeAnimatorController = Resources.Load("1") as RuntimeAnimatorController;
        } else
        {
            thisAnimator.runtimeAnimatorController = Resources.Load("2_1") as RuntimeAnimatorController;
        }
    }

    private void OnMouseDown()
    {
        if (canJump)
        {
            float jumpVelocity = 23.5f;
            rb.velocity = Vector2.up * jumpVelocity;
            BarkSound.Play();
            thisAnimator.speed = 0;
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "INVI_PLATFORM")
        {
            thisAnimator.speed = previousAnimSpeed;
            canJump = true;
        }
    }
}
