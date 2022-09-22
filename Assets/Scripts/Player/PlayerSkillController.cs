using System.Collections;
using UnityEngine;

public enum ESkill
{
    rocket,
    shield,
    magnetize,
    none
}

public class PlayerSkillController : MonoBehaviour
{
    public ESkill eSkill;
    public float ShieldTime = 3f;
    public float MagnetizeTime = 5f;
    public GameObject shieldGO;
    public GameObject rocketPrefab, rocketSpawnPoint;
    public float rocketSpeed;
    private Enemy enemy;
    public PlayerHealth playerHealth;

    private void Start()
    {
        eSkill = ESkill.none;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        playerHealth = GetComponent<PlayerHealth>();
        shieldGO.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ActivateSkill();
    }

    public void ActivateSkill()
    {
        switch (eSkill)
        {
            case ESkill.rocket:
                GameObject rocketGO = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, Quaternion.identity);
                rocketGO.transform.LookAt(enemy.gameObject.transform);
                rocketGO.tag = "PlayerToEnemy";
                StartCoroutine(FollowMissileCo(rocketGO));
                break;

            case ESkill.shield:
                if (playerHealth.hasShield)
                {
                    StopCoroutine(DeactivateShieldCo());
                    DeactiveShield();
                }                    
                playerHealth.hasShield = true;
                shieldGO.SetActive(true);
                StartCoroutine(DeactivateShieldCo());
                break;

            case ESkill.magnetize:
                enemy.SetSpeed(enemy.MagnetizedSpeed);
                StartCoroutine(DeactivateMagnetizeCo());
                break;

            case ESkill.none:
                break;
        }
        eSkill = ESkill.none;
    }

    private IEnumerator FollowMissileCo(GameObject rocket)
    {
        while (Vector3.Distance(
            new Vector3(enemy.transform.position.x, enemy.transform.position.y + 3, enemy.transform.position.z),
            rocket.transform.position) > 1f)
        {
            Vector3 enemyUpPos =
            new Vector3(enemy.transform.position.x, enemy.transform.position.y + 3, enemy.transform.position.z);
            rocket.transform.position +=
                (enemyUpPos - rocket.transform.position).normalized * rocketSpeed * Time.deltaTime;
            rocket.transform.LookAt(enemyUpPos);
            yield return null;
        }
        while (Vector3.Distance(enemy.transform.position, rocket.transform.position) > 1f)
        {
            rocket.transform.position +=
                (enemy.transform.position - rocket.transform.position).normalized * rocketSpeed * Time.deltaTime;
            rocket.transform.LookAt(enemy.gameObject.transform);
            yield return null;
        }
        Destroy(rocket);
    }

    private IEnumerator DeactivateShieldCo()
    {
        yield return new WaitForSeconds(ShieldTime);
        DeactiveShield();
    }

    public void DeactiveShield()
    {
        playerHealth.hasShield = false;
        shieldGO.SetActive(false);
    }

    private IEnumerator DeactivateMagnetizeCo()
    {
        yield return new WaitForSeconds(MagnetizeTime);
        enemy.SetSpeed(enemy.zSpeed);
    }
}