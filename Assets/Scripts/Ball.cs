/*
 * Author: Daniel Jacoby
 * Date 2/4/21
 * Project: 3D Pong
 * Abstract: It's pong, not rocket science. Kinda shitty pong, but pong with Unity Particle System so something?
 */

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
    public float dynamicDifficulty = 1f;

    public AudioClip goalSound;
    public AudioClip impactSound;

    private AudioSource _audioSource;

    private int _scoreP1 = 0;
    private int _scoreP2 = 0;

    private Vector3 _originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // goalSound = GetComponent<AudioClip>();
        // impactSound = GetComponent<AudioClip>();

        _audioSource = GetComponent<AudioSource>();
        
        float rx = Random.Range(0, 2) == 0 ? -1 : 1;
        float ry = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * rx, speed * ry, 0f);
        
        _originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_scoreP1 == 11)
        {
            PlaySound(goalSound);
            var str = "Game Over, P1 WINS";
            txt.text = str;
            Debug.Log(str);
            ResetGame();
            dynamicDifficulty += 10f;
        } 
        if (_scoreP2 == 11)
        {
            PlaySound(goalSound);
            var str = "Game Over, P2 WINS";
            txt.text = str;
            Debug.Log(str);
            ResetGame();
            dynamicDifficulty += 10f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // within the player hit, check where it is on the bumper and increase/decrease speed accordingly
        if (other.gameObject.CompareTag("GoalRight"))
        {
            PlaySound(goalSound);
            _scoreP1++;
            Debug.Log("Hit Right Goal P1 Points: " + _scoreP1);
            var str = _scoreP1 + " -- " + _scoreP2;
            txt.text = str;
            ResetBallPosition(other);
        } 
        if (other.gameObject.CompareTag("GoalLeft"))
        {
            PlaySound(goalSound);
            _scoreP2++;
            Debug.Log("Hit Left Goal P2 Points: " + _scoreP2);
            var str = _scoreP1 + " -- " + _scoreP2;
            txt.text = str;
            ResetBallPosition(other);
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            PlaySound(impactSound);
            var newSpeed = speed + 2f * dynamicDifficulty;
            Debug.Log("Hit Bumper Increase Speed to: " + newSpeed);
            speed = newSpeed;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            PlaySound(impactSound);
        }
    }

    private void ResetBallPosition(Collision obj)
    {
        transform.position = _originalPosition;
        speed = 5f;
        
    }
    
    private void ResetGame()
    {
        transform.position = _originalPosition;
        speed = 5f;
        _scoreP1 = 0;
        _scoreP2 = 0;
        var str = _scoreP1 + " -- " + _scoreP2;
        txt.text = str;
    }

    private void PlaySound(AudioClip soundClip)
    {
        _audioSource.clip = soundClip;
        _audioSource.Play();
    }
    
}
