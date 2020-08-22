using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring : MonoBehaviour
{
    public Rigidbody rb;
    float maxForce = 25000;
    float minForce = 10000;
    float curentforce = 0;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButton("Jump"))
        {
            transform.position = new Vector3(transform.position.x,transform.position.y-0.01f,transform.position.z);
            curentforce+=500;
        }
        else if(Input.GetButtonUp("Jump"))
        {
            rb.AddForce(Vector3.up * Mathf.Clamp(curentforce, minForce, maxForce));
            curentforce = 0;
            AudioManager.instance.StartPlaying("spring");
        }
        else if(transform.position.y>startPosition.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
    }
}
