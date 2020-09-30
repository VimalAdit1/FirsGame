using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public int winScore;
    public GameObject levelExit;
    public GameObject camera;
    bool isComplete;
    // Start is called before the first frame update
    void Start()
    {
        levelExit.SetActive(false);
        camera.SetActive(false);
        isComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetScore() >= winScore&&!isComplete)
        {
            levelExit.SetActive(true);
            StartCoroutine(SwitchCamera());
            isComplete = true;
        }
    }
    IEnumerator SwitchCamera()
    {
        camera.SetActive(true);
        yield return new WaitForSeconds(3);
        camera.SetActive(false);
    }
}
