using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject impactEffect;
    public GameObject slowmoEffect;
    public GameObject slowmoEffect2;
    public LineRenderer lineRenderer;
    public Rigidbody rb;
    public GameObject floor;
    public float BallForce = 2f;
    public float dragDuration = 3f;
    Vector3 startPosition;
    Vector3 endPosition;
    float minForce = -5f;
    float maxForce = 5f;
    float nextPower;
    bool dragInitiated;
    void Start()
    {
        slowmoEffect.SetActive(false);
        slowmoEffect2.SetActive(false);
        nextPower = Time.time + 0f;
        dragInitiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Gravity
        if(transform.position.z<floor.transform.position.z)
        {
            rb.AddForce(Vector3.forward*9.8f);
        }
        if(Input.GetButtonDown("Fire1")&&Time.time>=nextPower&&dragInitiated==false)
        {
            slowmoEffect.SetActive(true);
            slowmoEffect2.SetActive(true);
            dragInitiated = true;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition.z = -3.738281f;
        } 
        if(Input.GetButton("Fire1")&&dragInitiated)
        {
            slowmoEffect.SetActive(true);
            slowmoEffect2.SetActive(true);
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPosition.z = -3.738281f;
            DrawLine(startPosition, endPosition);
        }
        else if(Input.GetButtonUp("Fire1")&&dragInitiated)
        {
            slowmoEffect.SetActive(false);
            slowmoEffect2.SetActive(false);
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            Vector3 force = new Vector3(Mathf.Clamp((startPosition.x - endPosition.x), minForce, maxForce), Mathf.Clamp((startPosition.y - endPosition.y), minForce, maxForce),0);
            rb.AddForce(force*BallForce, ForceMode.Impulse);
            lineRenderer.positionCount = 0;
            dragInitiated = false;
        }    
    }
    void DrawLine(Vector3 start,Vector3 end)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,startPosition);
        lineRenderer.SetPosition(1,endPosition);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        GameObject effect = Instantiate(impactEffect,contact.point,Quaternion.FromToRotation(Vector3.forward, contact.normal));
        Destroy(effect,2f);
    }
}
