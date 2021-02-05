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

    public AudioClip goalSound;
    public AudioClip impactSound;

    private AudioSource _audioSource;

    private int scoreP1 = 0;
    private int scoreP2 = 0;

    private Vector3 originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // goalSound = GetComponent<AudioClip>();
        // impactSound = GetComponent<AudioClip>();

        _audioSource = GetComponent<AudioSource>();
        
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
            PlaySound(goalSound);
            var str = "P1 WINS";
            txt.text = str;
            Debug.Log(str);
            ResetGame();

        } 
        if (scoreP2 == 11)
        {
            PlaySound(goalSound);
            var str = "P2 WINS";
            txt.text = str;
            Debug.Log(str);
            ResetGame();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // within the player hit, check where it is on the bumper and increase/decrease speed accordingly
        if (other.gameObject.CompareTag("GoalRight"))
        {
            PlaySound(goalSound);
            scoreP1++;
            Debug.Log("Hit Right Goal P1 Points: " + scoreP1);
            var str = scoreP1 + " -- " + scoreP2;
            txt.text = str;
            ResetBallPosition();
        } 
        if (other.gameObject.CompareTag("GoalLeft"))
        {
            PlaySound(goalSound);
            scoreP2++;
            Debug.Log("Hit Left Goal P2 Points: " + scoreP2);
            var str = scoreP1 + " -- " + scoreP2;
            txt.text = str;
            ResetBallPosition();
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            PlaySound(impactSound);
            var NewSpeed = speed + 2f;
            Debug.Log("Hit Bumper Increase Speed to: " + NewSpeed);
            speed = NewSpeed;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            PlaySound(impactSound);
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

    void PlaySound(AudioClip soundClip)
    {
        _audioSource.clip = soundClip;
        _audioSource.Play();
    }
    
}
