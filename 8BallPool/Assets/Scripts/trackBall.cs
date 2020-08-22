using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackBall : MonoBehaviour
{
    public Transform cueBall;
    public Rigidbody rbBall;

    // Update is called once per frame
    void Update()
    {
        if (rbBall.velocity == Vector3.zero)
        {
            transform.position = cueBall.position;
        }
    }
}
