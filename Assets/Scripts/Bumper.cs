using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bumper : MonoBehaviour
{

    [FormerlySerializedAs("BumperP1")] public bool bumperP1;
    public float speed = 5f;

    private float _oldYp1;

    private float _oldYp2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bumperP1)
        {
            var newYp1 = Input.GetAxis("VerticalP1") * speed * Time.deltaTime;
            //if (newYP1 > 4 || newYP1 < -4) newYP1 = oldYP1;
            transform.Translate(0f, newYp1, 0f);
            //oldYP1 = newYP1;
        }
        else
        {
            var newYp2 = Input.GetAxis("VerticalP2") * speed * Time.deltaTime;
            //if (newYP2 > 4 || newYP2 < -4) newYP2 = oldYP2;
            transform.Translate(0f, newYp2, 0f);
            //oldYP2 = newYP2;
        }
    }
}
