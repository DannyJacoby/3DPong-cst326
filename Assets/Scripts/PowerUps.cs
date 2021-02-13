using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public bool isNegativePowerUp;

    private float speed;

    // private bool hasStarted = false;
    // public float bounceSpeed = 2.0f;

    // private bool dirUp = true;

    private Vector3 pos1 = new Vector3(0, -8, -10);
    private Vector3 pos2 = new Vector3(0, 8, -10);

    // private Bumper player1;
    // Start is called before the first frame update
    void Start()
    {
        speed = (isNegativePowerUp) ? -2 : 2;
        // dirUp = !isNegativePowerUp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallObject"))
        {
            var currentX = other.gameObject.transform.position.x;
            Debug.Log(other.gameObject.name + " has hit " + this.gameObject.name);
            Debug.Log(other.gameObject.name + " has hit at " + other.gameObject.transform.position.x);
            // Debug.Log("Player 1 is " + player1.gameObject.name);
            if (currentX < 0) //coming from p2
            {
                if (isNegativePowerUp)
                {
                    
                }
                else
                {
                    
                }
            }
            else if (currentX > 0) //coming from p1
            {
                if (isNegativePowerUp)
                {
                    
                }
                else
                {
                    
                }
            }
        }

    }

}
