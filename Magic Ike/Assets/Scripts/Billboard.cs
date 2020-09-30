using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Transform sceneCamera;

    private void Awake()
    {
        sceneCamera = Camera.main.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + sceneCamera.forward);
    }
}
