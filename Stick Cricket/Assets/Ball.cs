using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isBowling = false;
    public bool isHit = false;
    public bool isLeft = false;
    public bool isRight = false;
    public bool isMiddle = false;
    public int score;
    public Animator ballAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Bowl();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HitLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            HitRight();
        }
    }

    void Bowl()
    {
        isBowling = true;
        //int direction = Random.Range(1, 4);
        int direction = 2;
        switch (direction)
        {

            case 1:  ballAnimator.SetBool("isLeft", true);break;
            case 2:  ballAnimator.SetBool("isRight", true);break;
            case 3:  ballAnimator.SetBool("isMiddle", true);break;
            default:  ballAnimator.SetBool("isRight", true);break;
        }
    }
    private void Reset()
    {
        //Reset Anim Parameters
        ballAnimator.SetBool("isLeft", false);
        ballAnimator.SetBool("isRight", false);
        ballAnimator.SetBool("isMiddle", false);
        ballAnimator.SetBool("isHit", false);
        ballAnimator.SetInteger("score", 0);
        //Reset GameObject Parameters
        isBowling = false;
        isHit = false;
        isLeft = false;
        isRight = false;
        isMiddle = false;
    }

    void HitRight()
    {
        if(isBowling)
        {
            if (!isHit)
            {
                if (isRight)
                {
                    if (score > 0 )
                    {
                        isHit = true;
                        int currentScore = score;
                        currentScore = currentScore > 4 ? 6 : currentScore;
                        PlayAnimation(currentScore, isLeft);
                    }
                    else
                    {
                        Debug.Log("Miss");
                    }
                    //Bat Animation
                }
            }
        }
    }
    void HitLeft()
    {
        if (isBowling)
        {
            if (!isHit)
            {
                if (isLeft)
                {
                    if (score >0)
                    {
                        isHit = true;
                        int currentScore = score;
                        currentScore = currentScore > 4 ? 6 : currentScore;
                        PlayAnimation(currentScore, isLeft);
                    }
                    Debug.Log("Miss");
                    //Bat Animation
                }
            }
        }
    }
    void PlayAnimation(int curentScore,bool isLeft)
    {
        int outProb = Random.Range(0, 10);
        if(outProb!=10)
        {
            Debug.Log(curentScore);
            ballAnimator.SetBool("isHit", true);
            ballAnimator.SetInteger("score", curentScore);
        }
        else
        {
            Debug.Log("Out");
            ballAnimator.SetBool("isHit", true);
            ballAnimator.SetInteger("score", -1);
        }
            
        
    }
}
