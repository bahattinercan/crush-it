using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody myBody;

    public void Move(float speed)
    {
        myBody.AddForce(transform.forward.normalized * speed);
        Invoke("DeactivateGameObject", 5f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.CompareTag("Obstacle")|| target.gameObject.CompareTag("Zombie"))
        {
            gameObject.SetActive(false);
        }
    }

}
