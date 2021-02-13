using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bumper : MonoBehaviour
{

    [FormerlySerializedAs("BumperP1")] public bool bumperP1;
    public float speed = 5f;

    public float scaleVariable = 5f;
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
        // if (bumperP1)
        // {
        //     var newYp1 = Input.GetAxis("VerticalP1") * speed * Time.deltaTime;
        //     // if (newYp1 > 9 || newYp1 < -9) newYp1 = _oldYp2;
        //     transform.Translate(0f, Input.GetAxis("VerticalP1") * speed * Time.deltaTime, 0f);
        //     //oldYP1 = newYP1;
        // }
        // else
        // {
        //     // var newYp2 = Input.GetAxis("VerticalP2") * speed * Time.deltaTime;
        //     //if (newYP2 > 4 || newYP2 < -4) newYP2 = oldYP2;
        //     transform.Translate(0f, Input.GetAxis("VerticalP2") * speed * Time.deltaTime, 0f);
        //     //oldYP2 = newYP2;
        // }
    }

    public void increaseSize()
    {
        this.gameObject.transform.localScale += new Vector3(0, scaleVariable, 0);
    }

    public void decreaseSize()
    {
        this.gameObject.transform.localScale -= new Vector3(0, scaleVariable, 0);
    }
}
