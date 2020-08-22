using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public int winScore;
    public GameObject levelExit;
    // Start is called before the first frame update
    void Start()
    {
        levelExit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetScore() >= winScore)
        {
            levelExit.SetActive(true);
        }
    }
}
