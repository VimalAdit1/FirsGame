using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exitPortal;
    public GameObject ball;
    public Vector3 offset;
    public Boolean isActive;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Ball"))
        {
            ball.transform.position = exitPortal.transform.position + offset;
            AudioManager.instance.StartPlaying("portal");
        }
    }
}
