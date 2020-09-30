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
    public Material normal;
    public Material powerEnabled;
    public float ballForce = 2f;
    public float dragDuration = 3f;
    public float lineLength;
    public float zOffset;
    public float cooldown = 5f;
    public GameObject slowMoPost;
    Vector3 endPosition;
    Vector3 ballPosition;
    float minForce = -5f;
    float maxForce = 5f;
    float nextPower;
    bool dragInitiated;
    Renderer renderer;
    bool material = false;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        slowmoEffect.SetActive(false);
        slowmoEffect2.SetActive(false);
        slowMoPost.SetActive(false);
        nextPower = Time.time + cooldown;
        dragInitiated = false;
        renderer.material = normal;
    }

    // Update is called once per frame
    void Update()
    {
        if(!material&&isPowerEnabled())
        {
            renderer.material = powerEnabled;
            material = true;
        }
        //Gravity
        if(transform.position.z<floor.transform.position.z)
        {
            rb.AddForce(Vector3.forward*9.8f);
        }
        if(Input.GetButtonDown("Fire1")&&isPowerEnabled()&&dragInitiated==false)
        {
            dragInit();
        } 
        if(Input.GetButton("Fire1")&&dragInitiated)
        {
            
            ballPosition = transform.position;
            ballPosition.z = zOffset;
            endPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
            endPosition.z = zOffset;
            Vector3 direction = ballPosition - endPosition;
            DrawLine(direction.normalized,ballPosition);
        }
        else if(Input.GetButtonUp("Fire1")&&dragInitiated)
        {
            dragExit();
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
    void dragInit()
    {
        AudioManager.instance.StartPlaying("Slowmo");
        slowmoEffect.SetActive(true);
        slowmoEffect2.SetActive(true);
        slowMoPost.SetActive(true);
        dragInitiated = true;
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    void dragExit()
    {
        slowmoEffect.SetActive(false);
        slowmoEffect2.SetActive(false);
        slowMoPost.SetActive(false);
        dragInitiated = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        Vector3 force = new Vector3(Mathf.Clamp((lineRenderer.GetPosition(0).x - lineRenderer.GetPosition(1).x), minForce, maxForce), Mathf.Clamp((lineRenderer.GetPosition(0).y - lineRenderer.GetPosition(1).y), minForce, maxForce), 0);
        rb.AddForce(force * ballForce, ForceMode.Impulse);
        lineRenderer.positionCount = 0;
        nextPower = Time.time + cooldown;
        material = false;
        renderer.material = normal;
        AudioManager.instance.StartPlaying("ReleaseSlowmo");
    }

    bool isPowerEnabled()
    {
        return Time.time >= nextPower;
    }
}
