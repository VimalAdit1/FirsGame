using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int scorePerBounce;
    public GameManager gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        gameManager.AddScore(scorePerBounce);
        AudioManager.instance.StartPlaying("score");
    }
}
