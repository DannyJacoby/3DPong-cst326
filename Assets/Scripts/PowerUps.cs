using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public bool isNegativePowerUp;

    public float minScale = 1f;
    public float maxScale = 10f;

    private float speed;

    // private bool hasStarted = false;
    // public float bounceSpeed = 2.0f;

    // private bool dirUp = true;

    private Vector3 pos1 = new Vector3(0, -8, -10);
    private Vector3 pos2 = new Vector3(0, 8, -10);

    private Bumper player1;
    private Bumper player2;

    // private Bumper player1;
    // Start is called before the first frame update
    void Start()
    {
        speed = (isNegativePowerUp) ? -2 : 2;
        GameObject gm1 = GameObject.FindWithTag("Player1");
        player1 = gm1.GetComponent<Bumper>();
        GameObject gm2 = GameObject.FindWithTag("Player2");
        player2 = gm2.GetComponent<Bumper>();
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
            // Debug.Log(other.gameObject.name + " has hit " + this.gameObject.name);
            // Debug.Log(other.gameObject.name + " has hit at " + other.gameObject.transform.position.x);
            // Debug.Log("Player 1 is " + player1.gameObject.name);
            if (currentX < 0) //coming from p2
            {
                if (isNegativePowerUp)
                {
                    player2.IncreaseSize(1f + Time.deltaTime);
                    player2.DecreasePaddleSpeed(1f + Time.deltaTime);
                }
                else
                {
                    player1.DecreaseSize(1f + Time.deltaTime);
                    player1.IncreasePaddleSpeed(1f + Time.deltaTime);
                }
            }
            else if (currentX > 0) //coming from p1
            {
                // make different Player Tags for this specific issue (how do I know which player I'm grabbing)
                if (isNegativePowerUp)
                {
                    player1.IncreaseSize(1f + Time.deltaTime);
                    player1.DecreasePaddleSpeed(1f + Time.deltaTime);
                }
                else
                {
                    player2.DecreaseSize(1f + Time.deltaTime);
                    player2.IncreasePaddleSpeed(1f + Time.deltaTime);
                }
            }
        }

    }

}
