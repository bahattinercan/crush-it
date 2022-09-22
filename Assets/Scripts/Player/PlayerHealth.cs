using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int healthValue = 100;
    public bool hasShield;
    private Slider healthSlider;
    private GameObject uiHolder;
    private PlayerSkillController skillController;
    private void Start()
    {
        healthSlider = GameObject.Find("Health Bar").GetComponent<Slider>();
        healthSlider.value = healthValue;
        uiHolder = GameObject.Find("UI Holder");
        skillController = GetComponent<PlayerSkillController>();
    }
    public void ApplyDamage(int damageAmount)
    {
        if (hasShield)
        {
            hasShield = false;
            AudioController.instance.PlayOneShot(AudioController.instance.shieldHitClip,1f);
            skillController.DeactiveShield();
            GameplayController.instance.IncreaseScore();
        }
        else
        {
            healthValue -= damageAmount;
            if (healthValue < 0)
                healthValue = 0;
            healthSlider.value = healthValue;
            if (healthValue == 0)
            {
                uiHolder.SetActive(false);
                Invoke("GameOver", .001f);
                
            }
        }        
    }
    private void GameOver()
    {
        GameplayController.instance.GameOver();
    }
}

