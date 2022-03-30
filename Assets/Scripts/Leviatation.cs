using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leviatation : MonoBehaviour
{
    [SerializeField]
    private Transform levitation_Object;


    private void Start()
    {
        levitation_Object = this.GetComponent<Transform>();
        Float();
    }


    private void Float()
    {
        levitation_Object.position = new Vector3(Random.Range(-5.5f,5.5f), Random.Range(-1.5f, 1.5f), transform.position.z);
    }
}
