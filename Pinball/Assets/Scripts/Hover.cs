
using UnityEngine;

public class Hover : MonoBehaviour
{
    public bool isClockwise;
    public float xRotationFactor = 0f;
    public float yRotationFactor = 0f;
    public float zRotationFactor = 0.02f;
    Vector3 rotateOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (isClockwise)
        {
            zRotationFactor = zRotationFactor * -1;
        }
      rotateOffset = new Vector3(xRotationFactor, yRotationFactor, zRotationFactor);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.eulerAngles+rotateOffset*Time.deltaTime);
    }
}
