/*
 * Author: Daniel Jacoby
 * Date 2/4/21
 * Project: 3D Pong
 * Abstract: It's pong, not rocket science. Kinda shitty pong, but pong with Unity Particle System so something?
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public float speed = 10f;
    public TextMeshProUGUI txt;
    public TextMeshProUGUI p1ScoreTxt;
    public TextMeshProUGUI p2ScoreTxt;
    public float dynamicDifficulty = 1f;

    public AudioClip goalSound;
    public AudioClip impactSound;
    public AudioClip posPaddleImpactSound;
    public AudioClip negPaddleImpactSound;

    private AudioSource _audioSource;

    private int _scoreP1 = 0;
    private int _scoreP2 = 0;

    private Vector3 _originalPosition;

    // private float r = 0.2f, g = 0.3f, b = 0.7f, a = 0.6f;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        float rx = Random.Range(0, 2) == 0 ? -1 : 1;
        float ry = Random.Range(0, 2) == 0 ? -1 : 1;

        GetComponent<Rigidbody>().velocity = new Vector3(speed * rx, speed * ry, 0f);
        
        _originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_scoreP1 < _scoreP2) { p1ScoreTxt.color = Color.red; }
        else if (_scoreP1 == _scoreP2) { p1ScoreTxt.color = Color.white; }
        else { p1ScoreTxt.color = Color.green; }
        if (_scoreP2 < _scoreP1) { p2ScoreTxt.color = Color.red; }          
        else if (_scoreP1 == _scoreP2) { p2ScoreTxt.color = Color.white; }
        else { p2ScoreTxt.color = Color.green; }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // within the player hit, check where it is on the bumper and increase/decrease speed accordingly
        if (other.gameObject.CompareTag("GoalRight"))
        {
            var str = "";
            if (_scoreP1 == 11)
            {
                PlaySound(goalSound);
                str = "Game Over, P1 WINS";
                txt.text = str;
                Debug.Log(str);
                ResetGame();
                dynamicDifficulty += 10f;
                return;
            } 
            PlaySound(goalSound);
            _scoreP1++;
            Debug.Log("Hit Right Goal P1 Points: " + _scoreP1);
            str = _scoreP1.ToString();
            p1ScoreTxt.text = str;
            
            ResetBallPosition(other);
        } 
        if (other.gameObject.CompareTag("GoalLeft"))
        {
            var str = "";
            if (_scoreP2 == 11)
            {
                PlaySound(goalSound);
                str = "Game Over, P2 WINS";
                txt.text = str;
                Debug.Log(str);
                ResetGame();
                dynamicDifficulty += 10f;
                return;
            }
            PlaySound(goalSound);
            _scoreP2++;
            Debug.Log("Hit Left Goal P2 Points: " + _scoreP2);
            str = _scoreP2.ToString();
            p2ScoreTxt.text = str;
            
            ResetBallPosition(other);
        }
        
        if (other.gameObject.CompareTag("Player"))
        {
            var relativeBallToPaddlePosition = this.transform.position.y - other.transform.position.y; // Ball pos y - Paddle pos y
            PlaySound(relativeBallToPaddlePosition <= 0 ? negPaddleImpactSound : posPaddleImpactSound);
           
            // check if this.x is positive (coming from P1) if negative (coming from P2)
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
