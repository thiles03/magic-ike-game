using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform player = null;
 
    private Vector3 offset = new Vector3(0, -2, 2);
    private float pitch = 2f;
    private float minZoom = 5f;
    private float maxZoom = 15;
    private float currentZoom = 10f;
    private float zoomSpeed = 4f;


    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    void LateUpdate()
    {
        transform.position = player.position - offset * currentZoom;
        transform.LookAt(player.position + Vector3.up * pitch);
    }
}
