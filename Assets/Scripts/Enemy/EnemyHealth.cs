using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int healthValue = 100;
    public bool hasShield;
    private Slider healthSlider;
    private GameObject uiHolder;
    EnemySkillController skillController;

    private void Start()
    {
        healthSlider = GameObject.Find("Enemy Health Bar").GetComponent<Slider>();
        healthSlider.value = healthValue;
        uiHolder = GameObject.Find("UI Holder");
        skillController = GetComponent<EnemySkillController>();
    }

    public void ApplyDamage(int damageAmount)
    {
        if (hasShield)
        {
            hasShield = false;
            AudioController.instance.PlayOneShot(AudioController.instance.shieldHitClip,1f);
            skillController.DeactiveShield();
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
                Invoke("Win", .001f);                
            }
        }
    }

    private void Win()
    {
        GameplayController.instance.WinTheGame();
    }
}