using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkillController : MonoBehaviour
{
    public ESkill eSkill;
    public float ShieldTime = 3f;
    public float MagnetizeTime = 5f;
    public GameObject shieldGO;
    public GameObject rocketPrefab, rocketSpawnPoint;
    public float rocketSpeed = 25f;
    private float randomPointDistance=8f;
    private PlayerController player;
    private EnemyHealth enemyHealth;
    private void Start()
    {
        eSkill = ESkill.none;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        enemyHealth = GetComponent<EnemyHealth>();
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
                rocketGO.tag = "EnemyToPlayer";
                rocketGO.transform.LookAt(player.transform);
                StartCoroutine(FollowMissileCo(rocketGO));
                break;
            case ESkill.shield:
                if (enemyHealth.hasShield)
                {
                    StopCoroutine(DeactivateShieldCo());
                    DeactiveShield();
                }
                enemyHealth.hasShield = true;
                shieldGO.SetActive(true);
                StartCoroutine(DeactivateShieldCo());              
                break;
            case ESkill.magnetize:
                player.SetSpeed(player.baseZSpeed);
                StartCoroutine(DeactivateMagnetizeCo());
                break;
            case ESkill.none:
                break;
        }
        eSkill = ESkill.none;
    }

    private IEnumerator FollowMissileCo(GameObject rocket)
    {
        float rocketYDistance = 4;
        while (Vector3.Distance(
            new Vector3(player.transform.position.x, player.transform.position.y + rocketYDistance, player.transform.position.z),
            rocket.transform.position) > 1f)
        {
            Vector3 playerUpPos =new Vector3(player.transform.position.x, 
            player.transform.position.y + rocketYDistance, 
            player.transform.position.z);
            
            rocket.transform.position +=
                (playerUpPos - rocket.transform.position).normalized * rocketSpeed * Time.deltaTime;
            rocket.transform.LookAt(playerUpPos);
            yield return null;
        }
        float randomDistanceX = Random.Range(0, randomPointDistance);
        Vector3 randomVector3 = 
            new Vector3(player.transform.position.x + randomDistanceX,
            player.transform.position.y,
            player.transform.position.z);
        while (Vector3.Distance(
            new Vector3(player.transform.position.x + randomDistanceX, 
            player.transform.position.y, 
            player.transform.position.z),
            rocket.transform.position) > .1f)
        {
            randomVector3= new Vector3(player.transform.position.x + randomDistanceX,
            player.transform.position.y,
            player.transform.position.z);
            rocket.transform.position +=
                (randomVector3 - rocket.transform.position).normalized * rocketSpeed * Time.deltaTime;
            
            rocket.transform.LookAt(randomVector3);
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
        enemyHealth.hasShield = false;
        shieldGO.SetActive(false);
    }

    private IEnumerator DeactivateMagnetizeCo()
    {
        yield return new WaitForSeconds(MagnetizeTime);
        player.SetSpeed(player.zSpeed);
    }

}
