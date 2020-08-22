using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleScriptOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public MonoBehaviour script;
    public bool valueToSet;

    private void OnTriggerEnter(Collider other)
    {

        script.enabled = valueToSet;
    }
}
