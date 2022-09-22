using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosionFX;
    public int damage = 34;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && CompareTag("EnemyToPlayer"))
        {
            ExplosionFX();
            other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
        }
        else if ((other.CompareTag("Enemy") && CompareTag("PlayerToEnemy")))
        {
            ExplosionFX();
            other.gameObject.GetComponent<EnemyHealth>().ApplyDamage(damage);
        }
        else if ((other.CompareTag("GroundBlock") || other.CompareTag("Obstacle")) && CompareTag("EnemyToPlayer"))
        {
            ExplosionFX();
        }
    }

    private void ExplosionFX()
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Stop();
        AudioController.instance.PlayOneShot(AudioController.instance.explosionClip);
    }
}