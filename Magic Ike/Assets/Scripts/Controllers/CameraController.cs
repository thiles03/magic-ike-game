using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Zoom Variables")]
    public float pitch = 2f;
    public float minZoom = 5f;
    public float maxZoom = 15;
    public float currentZoom = 10f;
    public float zoomSpeed = 4f;

    //Starting camera offset
    private Vector3 offset = new Vector3(0, -2, 2);

    //Reference to the player
    private Transform player;

    private void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

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
