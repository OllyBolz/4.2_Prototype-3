using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private float jumpForce = 40f;
    private float dJumpMultiplier = 0.8f;
    private float gravityModifier = 10f;

    public bool isOnGround = true;
    public bool dJump = false;

    public bool gameOver = false;
    private GameObject gOText;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        gOText = GameObject.Find("/Canvas/Game Over");
        gOText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && dJump)
        {
            playerRb.AddForce(Vector3.up * jumpForce * dJumpMultiplier, ForceMode.Impulse);
            dJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dJump = false;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        { 
            gameOver = true;
            gOText.SetActive(true);
            Debug.Log("Game Over");
        }
    }

}
