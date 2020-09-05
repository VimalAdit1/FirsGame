using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public int winScore;
    public GameObject levelExit;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        levelExit.SetActive(false);
        camera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetScore() >= winScore)
        {
            levelExit.SetActive(true);
            StartCoroutine(SwitchCamera());
        }
    }
    IEnumerator SwitchCamera()
    {
        camera.SetActive(true);
        yield return new WaitForSeconds(3);
        camera.SetActive(false);
    }
}
