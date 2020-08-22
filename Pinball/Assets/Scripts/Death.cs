using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private bool inGame;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        inGame = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ball")&&inGame)
        {
            inGame = false;
            gameManager.gameOver();
        }
    }
}
