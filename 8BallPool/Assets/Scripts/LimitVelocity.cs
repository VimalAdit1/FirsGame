using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitVelocity : MonoBehaviour
{
    private Rigidbody rb;
    public float min_velocity;
    public float max_velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.sqrMagnitude);
        if(rb.velocity.magnitude<min_velocity)
        {
            rb.velocity *= 0.99f;
        }
        if (rb.velocity.magnitude > max_velocity)
        {
            //smoothness of the slowdown is controlled by the 0.99f, 
            //0.5f is less smooth, 0.9999f is more smooth
            rb.velocity *= 0.99f;
        }
    }
}
