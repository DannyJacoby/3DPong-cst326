using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bumper : MonoBehaviour
{

    [FormerlySerializedAs("BumperP1")] public bool bumperP1;
    public float speed = 7f;

    // public float scaleVariable = 5f;
    // private float _oldYp1;
    // private float _oldYp2;

    private float currentYScale;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, ((bumperP1) ? Input.GetAxis("VerticalP1") : Input.GetAxis("VerticalP2")) * speed * Time.deltaTime, 0f );
    }

    public void IncreaseSize(float scaleVariable)
    {
        this.gameObject.transform.localScale += new Vector3(0, scaleVariable, 0);
    }

    public void DecreaseSize(float scaleVariable)
    {
        this.gameObject.transform.localScale -= new Vector3(0, scaleVariable, 0);
    }

    public void IncreasePaddleSpeed(float speedVariable)
    {
        this.speed += speedVariable;
    }

    public void DecreasePaddleSpeed(float speedVariable)
    {
        this.speed -= speedVariable;
    }

    public void ResetPaddle()
    {
        this.gameObject.transform.localScale = new Vector3(0.5f, 5f, 1f);
        this.speed = 7f;
    }
}
