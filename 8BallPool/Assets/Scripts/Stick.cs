using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public float movespeed = 300f;
    private float movement;
    public Transform cueBall;
    public Rigidbody rb;
    public Rigidbody rbBall;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {

        transform.RotateAround(cueBall.position,Vector3.up, -movement * movespeed * Time.fixedDeltaTime);
    }
    public void updateSpeed(float _speed)
    {
        speed = _speed;
    }
    public void hit()
    {
        Debug.Log("Triggered hit with Direction");
        //Vector3 direction = transform.position + (transform.forward.normalized * speed * Time.deltaTime);
        //Debug.Log(direction);
        //Debug.Log(transform.forward.normalized);
        //Debug.Log(transform.forward);
        Vector3  direction = transform.forward;
        direction.y = 0;
        rbBall.AddForce(direction*speed*Time.deltaTime,ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
       // gameObject.SetActive(false);
    }
}   
