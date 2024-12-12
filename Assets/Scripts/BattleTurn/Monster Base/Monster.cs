using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;

    public int currentHP;
    public int maxHP;
    public int energyPoints;

    void Start()
    {
        Debug.Log($"{monsterData.monsterName} tem {monsterData.currentHP} de HP e {monsterData.energyPoints} de energia.");

    }

    public int GetCurrentHP()
    {
        return monsterData.currentHP;
    }

    public int GetEnergyPoints()
    {
        return monsterData.energyPoints;
    }

    public void ModifyHealth(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        Debug.Log($"{name}: HP alterado para {currentHP}");
    }

    public void ModifyEnergy(int amount)
    {
        energyPoints = Mathf.Clamp(energyPoints + amount, 0, 100); // Supondo um limite de 100
        Debug.Log($"{name}: Energia alterada para {energyPoints}");
    }
}
