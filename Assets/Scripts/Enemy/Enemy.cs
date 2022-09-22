using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody myBody;
    private Vector3 speed;
    public float zSpeed = 15f;
    public float MagnetizedSpeed = 7f;


    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
        speed = new Vector3(0f, 0f, zSpeed);        
    }

    private void FixedUpdate()
    {
        myBody.MovePosition(myBody.position + speed * Time.deltaTime);
    }

    public void SetSpeed(float zSpeed)
    {
        speed = new Vector3(0f, 0f, zSpeed);
    }

    
}
