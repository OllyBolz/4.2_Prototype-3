using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private Rigidbody thisRb;

    private float speed = 7500f;
    private float leftBound = -20f;

    private PlayerController playerControllerScript;

    public bool isBarrel = false;
    private float barrelSpin;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update() //I changed some things to get rolling barrels :)
    {
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            return;
        }
        if (thisRb != null)
        {
            if (!playerControllerScript.gameOver)
            {
                if (isBarrel)
                {
                    barrelSpin += -90f * Time.deltaTime;
                    thisRb.velocity = Vector3.left * Time.deltaTime * speed * 1.75f; //faster barrels to spice things up
                    thisRb.rotation = Quaternion.Euler(barrelSpin, 90f, 90f);
                    return;
                }
                else
                {
                    thisRb.velocity = Vector3.left * Time.deltaTime * speed;
                    return;
                }
            }
            else 
            {
                if (isBarrel)
                {
                    thisRb.velocity = Vector3.left * Time.deltaTime * speed * 0.75f; //Barrels still move because I opted out of a complete pause for them to move according to their relative motion.
                    thisRb.rotation = Quaternion.Euler(0f, 90f, 90f);
                    return;
                }
                else
                {
                    thisRb.velocity = Vector3.zero;
                    return;
                }
            }
        }
        else
        {
            thisRb = GetComponent<Rigidbody>();
        }
    }
}
