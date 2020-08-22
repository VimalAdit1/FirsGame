using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] movePoints;
    public float speed;
    int currentMovePoint;
    void Start()
    {
        currentMovePoint = Random.Range(0, movePoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,movePoints[currentMovePoint].position,speed*Time.deltaTime);
        if(Vector2.Distance(transform.position,movePoints[currentMovePoint].position)<=0.2f)
        { 
            currentMovePoint = Random.Range(0, movePoints.Length);
        }
    }
}
