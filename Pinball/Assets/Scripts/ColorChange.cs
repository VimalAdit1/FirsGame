using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material baseMaterial;
    public Material[] onCollision;
    int noOfMaterials;
    Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = baseMaterial;
        noOfMaterials = onCollision.Length;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        //Many Materials
        if (noOfMaterials > 1)
        {
            int index = Random.Range(0, noOfMaterials);
            renderer.material = onCollision[index];
        }
        //Single Material
        else
        {
            renderer.material = onCollision[0];
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        renderer.material = baseMaterial;
    }
}
