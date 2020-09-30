using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public int scorePerBounce;
    public GameManager gameManager;
    Vector3 scaleFactor = new Vector3(0.06f, 0.06f, 0.06f);
    private void OnCollisionEnter(Collision collision)
    {
        gameManager.AddScore(scorePerBounce);
        AudioManager.instance.StartPlaying("score");
        StartCoroutine(DramaticScale());
    }

    IEnumerator DramaticScale()
    {
        transform.localScale += scaleFactor;
        yield return new WaitForSeconds(0.1f);
        transform.localScale -= scaleFactor;
    }
    public void Explode()
    {
        AudioManager.instance.StartPlaying("explosion");
    }
}
