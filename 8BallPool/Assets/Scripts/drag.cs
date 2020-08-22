using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float zCord;
    private float xMin=-0.88f;
    private float yVal=0.521f;
    private float xMax=-0.35f;
    private float zMin=-0.34f;
    private float zLine=0.35f;
    private void OnMouseDown()
    {
        zCord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
        Debug.Log("MouseDown");
    }

    private Vector3 GetMouseWorldPos()
    {
        
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        Vector3 position = GetMouseWorldPos() + mouseOffset;
        position = new Vector3(Mathf.Clamp(position.x, xMin, xMax), yVal, Mathf.Clamp(position.z, zMin, zLine));
        transform.position =position ;
        Debug.Log("Drag");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
