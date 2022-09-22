using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public ESkill powerType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSkillController playerSC = other.gameObject.GetComponent<PlayerSkillController>();
            playerSC.eSkill = powerType;
            playerSC.ActivateSkill();
            GameplayController.instance.IncreaseScore(10);
            Destroy(gameObject);
        }else if (other.CompareTag("Enemy"))
        {
            EnemySkillController enemySkill = other.gameObject.GetComponent<EnemySkillController>();
            enemySkill.eSkill = powerType;
            enemySkill.ActivateSkill();            
            Destroy(gameObject);
        }
    }
}