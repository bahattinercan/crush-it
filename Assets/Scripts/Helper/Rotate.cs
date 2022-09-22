using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotation=new Vector3(0,10,0);
    public float speed=10;

    private void Update()
    {
        transform.Rotate(rotation*speed * Time.deltaTime);
    }
}
