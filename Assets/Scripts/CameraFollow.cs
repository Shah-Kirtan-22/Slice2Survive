using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        this.transform.position = player.transform.position + offset;
    }
}
