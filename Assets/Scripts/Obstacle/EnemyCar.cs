using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public GameObject explosiveFX;
    private float speed = 1f;
    private Rigidbody myBody;
    private bool isAlive;

    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
        speed = Random.Range(1f, 5f);
        isAlive = true;
    }

    private void Update()
    {
        if (isAlive)
        {
            myBody.velocity = new Vector3(0, 0, -speed);
        }


        if (transform.position.y < -10)
        {
            gameObject.SetActive(false);
        }
    }

    void Die()
    {
        isAlive = false;
        myBody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("Idle");
        transform.rotation = Quaternion.Euler(90f, 0, 0);
        transform.localScale = new Vector3(1, 1, .2f);
        transform.position = new Vector3(transform.position.x, .2f, transform.position.z);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag("Player") || target.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosiveFX, transform.position, Quaternion.identity);
            Invoke("DeactivateGameObject", 3f);
            GameplayController.instance.IncreaseScore();
            Die();
        }
    }
}
