using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public Text txt;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    private Vector3 originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        float rx = Random.Range(0, 2) == 0 ? -1 : 1;
        float ry = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * rx, speed * ry, 0f);
        
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreP1 == 11)
        {
            var str = "P1 WINS";
            txt.text = str;
            ResetGame();

        } 
        if (scoreP2 == 11)
        {
            var str = "P2 WINS";
            txt.text = str;
            ResetGame();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("GoalRight"))
        {
            scoreP1++;
            Debug.Log("Hit Right Goal P1 Points: " + scoreP1);
            var str = scoreP1 + " -- " + scoreP2;
            txt.text = str;
            ResetBallPosition();
        } 
        if (other.gameObject.CompareTag("GoalLeft"))
        {
            scoreP2++;
            Debug.Log("Hit Left Goal P2 Points: " + scoreP2);
            var str = scoreP1 + " -- " + scoreP2;
            txt.text = str;
            ResetBallPosition();
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            var NewSpeed = speed + 2f;
            Debug.Log("Hit Bumper Increase Speed to: " + NewSpeed);
            speed = NewSpeed;
        }

        //Debug.Log("Hit a wall");
    }

    private void ResetBallPosition()
    {
        transform.position = originalPosition;
        speed = 5f;
    }
    
    public void ResetGame()
    {
        transform.position = originalPosition;
        speed = 5f;
        scoreP1 = 0;
        scoreP2 = 0;
        var str = scoreP1 + " -- " + scoreP2;
        txt.text = str;
    }
    
}
