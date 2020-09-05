using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Ball"))
        {
            gameManager.levelComplete();
        }
    }
}
