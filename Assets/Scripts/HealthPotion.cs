using UnityEngine;
using TMPro;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private int deadEnemyNumbers;

    private int potionCost = 5;

    [SerializeField] private int potionNumber;
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

    private void Health()
    {
        int health = combatPlayerV2.GetCurrentHealth();
        health += potion;
        healthBar.SetHealth(combatPlayerV2.SetCurrentHealth(health));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            if ( potionNumber > 0)
            {
                Health();
                potionNumber --;
                potions.text = "" + potionNumber;
            }
        }
    }
}
