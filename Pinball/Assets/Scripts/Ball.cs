using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject impactEffect;
    public GameObject slowmoEffect;
    public GameObject slowmoEffect2;
    public LineRenderer lineRenderer;
    public Rigidbody rb;
    public GameObject floor;
    public float ballForce = 2f;
    public float dragDuration = 3f;
    public float lineLength;
    public float zOffset;
    public float cooldown = 5f;
    Vector3 dragInitPosition;
    Vector3 startPosition;
    Vector3 endPosition;
    Vector3 ballPosition;
    float minForce = -5f;
    float maxForce = 5f;
    float nextPower;
    bool dragInitiated;
    void Start()
    {
        slowmoEffect.SetActive(false);
        slowmoEffect2.SetActive(false);
        nextPower = Time.time + cooldown;
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
            dragInitPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            startPosition = dragInitPosition;
     
        } 
        if(Input.GetButton("Fire1")&&dragInitiated)
        {
            Debug.Log("start position in drag" + startPosition);
            Debug.Log("In Drag");
            ballPosition = transform.position;
            ballPosition.z = zOffset;
            slowmoEffect.SetActive(true);
            slowmoEffect2.SetActive(true);
            Debug.Log(Input.mousePosition);
            endPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
            endPosition.z = zOffset;
            Debug.Log("end position in drag" + endPosition);
            Vector3 direction = startPosition - endPosition;
            DrawLine(direction,ballPosition);
        }
        else if(Input.GetButtonUp("Fire1")&&dragInitiated)
        {
 
            slowmoEffect.SetActive(false);
            slowmoEffect2.SetActive(false);
            Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            Vector3 force = new Vector3(Mathf.Clamp((lineRenderer.GetPosition(0).x - lineRenderer.GetPosition(1).x), minForce, maxForce), Mathf.Clamp((lineRenderer.GetPosition(0).y - lineRenderer.GetPosition(1).y), minForce, maxForce),0);
            rb.AddForce(force*ballForce, ForceMode.Impulse);
            lineRenderer.positionCount = 0;
            dragInitiated = false;
            nextPower = Time.time + cooldown;
        }    
    }
    void DrawLine(Vector3 start,Vector3 end)
    {
        start = new Vector3(Mathf.Clamp(start.x, -lineLength, lineLength), Mathf.Clamp(start.y, -lineLength, lineLength),start.z);
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,start+end);
        Debug.Log("start position" + start + end);
        Debug.Log("End position" +end);
        lineRenderer.SetPosition(1,end);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        GameObject effect = Instantiate(impactEffect,contact.point,Quaternion.FromToRotation(Vector3.forward, contact.normal));
        Destroy(effect,2f);
    }
}
