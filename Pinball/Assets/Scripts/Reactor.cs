using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator sphereAnimator;
    bool isUnstable;
    bool isDestroyed;
    float health = 500;
    public GameObject camera;
    public GameObject volume;
    public GameObject ball;
    public Transform tutorialLocation;
    void Start()
    {
        isUnstable = false;
        isDestroyed = false;
        camera.SetActive(false);
        volume.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(health<400&&!isUnstable)
        {
            isUnstable = true;
            StartCoroutine(SwitchCamera(3,isDestroyed));
            sphereAnimator.SetBool("isUnstable", isUnstable);
        }
        if (health <=0 && !isDestroyed&&isUnstable)
        {
            isDestroyed = true;
            StartCoroutine(SwitchCamera(4,isDestroyed));
            sphereAnimator.SetBool("isDestroyed", isDestroyed);
            AudioManager.instance.StartPlaying("explosion1");
            volume.SetActive(true);
        }
    }

    private void TeleportBall()
    {
        Ball b = ball.GetComponent<Ball>();
        b.enabled = true;
        b.cooldown = 5f;
        ball.transform.position = tutorialLocation.position;
        volume.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ball"))
        {
            hit();
        }
    }

    private void hit()
    {
        health -= 50;
    }
    IEnumerator SwitchCamera(int seconds,bool isDestroyed)
    {
        camera.SetActive(true);
        yield return new WaitForSeconds(seconds);
        camera.SetActive(false);
        if(isDestroyed)
        {
            TeleportBall();
        }
    }
}
