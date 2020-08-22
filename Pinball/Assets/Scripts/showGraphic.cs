using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showGraphic : MonoBehaviour
{
    public GameObject graphicToShow;
    private void Start()
    {
        graphicToShow.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            graphicToShow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.CompareTag("Ball"))
        {
        graphicToShow.SetActive(false);
        }
    }
}
