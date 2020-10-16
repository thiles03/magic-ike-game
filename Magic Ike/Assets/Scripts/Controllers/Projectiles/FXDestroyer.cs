using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDestroyer : MonoBehaviour
{
    private float time = 2f;
    void Start()
    {
        Destroy(gameObject, time);
    }
}
