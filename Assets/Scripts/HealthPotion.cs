using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] public int deadEnemyNumbers;

    private int potionCost = 5;

    [SerializeField] public int potionNumber;
    private int maxPotions = 3;

    [SerializeField] private CombatPlayerV2 combatPlayerV2;

    [SerializeField] private HealthBar healthBar;

    private int potion = 30;

    
    public void DeadEnemy()
    {
        if (potionNumber < maxPotions)
        {
            if (deadEnemyNumbers >= potionCost && potionNumber < maxPotions)
            {
                potionNumber ++;
                deadEnemyNumbers = 0;
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
            }
        }
    }
}
