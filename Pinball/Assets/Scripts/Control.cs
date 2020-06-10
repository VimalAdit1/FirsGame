using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    public HingeJoint hinge;
    public KeyCode input;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetKey(input))
            {
                hinge.useMotor = true;
            }
            else
            {
                hinge.useMotor = false;
            }
        
    }
   
}
