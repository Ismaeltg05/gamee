using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] public int deadEnemyNumbers;

    private int potionCost = 5;

    [SerializeField] public int potionNumber;
    private int maxPotions = 3;

    [SerializeField] private CombatPlayerV2 combatPlayerV2;

    [SerializeField] private HealthBar healthBar;

    private int potion = 30;

    [SerializeField] private TMP_Text potions;

    
    public void DeadEnemy()
    {
        if (potionNumber < maxPotions)
        {
            if (deadEnemyNumbers >= potionCost && potionNumber < maxPotions)
            {
                potionNumber ++;
                deadEnemyNumbers = 0;
                potions.text = "" + potionNumber;
            }
            else{
                deadEnemyNumbers ++;
            }
        }
    }

    private void Heal()
    {
        healthBar.SetHealth(combatPlayerV2.currentHealth += potion);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            if ( potionNumber > 0)
            {
                Heal();
                potionNumber --;
                potions.text = "" + potionNumber;
            }
        }
    }
}
