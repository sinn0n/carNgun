using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float rotateSpeed = 25.0f, speed = 25.0f, zoomSpped = 500.0f;
    private float _mult = 1f;

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        
        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q))
            rotate = -1f;
        if (Input.GetKey(KeyCode.E))
            rotate = 1f;

        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;        
        
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);

        transform.position += transform.up * zoomSpped * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -20f, 30f),
            transform.position.z);
    }
}
