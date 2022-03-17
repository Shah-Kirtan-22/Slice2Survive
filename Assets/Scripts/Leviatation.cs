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
        levitation_Object.position = new Vector3(Random.Range(-4,4), Random.Range(-2, 2), transform.position.z);
    }
}
