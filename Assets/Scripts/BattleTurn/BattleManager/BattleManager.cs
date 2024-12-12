using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{
    public enum BattleState {START, SELECT_PLAYER, PLAYER_TURN, ENEMY_TURN, WON, LOSE}
    public BattleState state;

    public List<Monster> playerMonsters = new List<Monster>();
    public List<Monster> enemyMonsters = new List<Monster>();

    public TMP_Text playerHPUI;
    public TMP_Text playerEnergyUI;
    
    public TMP_Text enemyHPUI;
    public TMP_Text enemyEnergyUI;

    public int playerTotalHP;
    public int playerTotalEnergy;

    void Start()
    {
        FindMonsters();

        state = BattleState.START;
        SetupBattle();
        UpdateTeamStatus();
    }

    void FindMonsters()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject obj in playerObjects)
        {
            Monster monster = obj.GetComponent<Monster>();
            Debug.Log($"Objeto encontrado para Hero: {obj.name}, Tag: {obj.tag}");
            if (monster != null)
            {
                playerMonsters.Add(monster);
            }
        }

        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in enemyObjects)
        {
            Monster monster = obj.GetComponent<Monster>();
            Debug.Log($"Objeto encontrado para Enemy: {obj.name}, Tag: {obj.tag}");
            if (monster != null)
            {
                enemyMonsters.Add(monster);
            }
        }
    }

    void SetupBattle()
    {
        state = BattleState.PLAYER_TURN;
        PlayerTurn();
    }
    
    void UpdateTeamStatus()
    {
        int totalPlayerHP = CalculateTotalHP(playerMonsters);
        int totalPlayerEnergy = CalculateTotalEnergy(playerMonsters);
        playerHPUI.text = totalPlayerHP.ToString();
        playerEnergyUI.text = totalPlayerEnergy.ToString();

        int totalEnemyHP = CalculateTotalHP(enemyMonsters);
        int totalEnemyEnergy = CalculateTotalEnergy(enemyMonsters);
        enemyHPUI.text = totalEnemyHP.ToString();
        enemyEnergyUI.text = totalEnemyEnergy.ToString();

        playerTotalHP = totalPlayerHP;
        playerTotalEnergy = totalPlayerEnergy;
    }

    void PlayerTurn()
    {
            
    }

    void EnemyTurn()
    {

    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Debug.Log("Você Ganhou!");
        }
        else if (state == BattleState.LOSE)
        {
            Debug.Log("Você Perdeu!");
        }
    }
    int CalculateTotalHP(List<Monster> monsters)
    {
        int playerTotalHP = 0;
        foreach (Monster monster in monsters)
        {
            playerTotalHP += monster.GetCurrentHP();
        }
        return playerTotalHP;
    }

    int CalculateTotalEnergy(List<Monster> monsters)
    {
        int playerTotalEnergy = 0;
        foreach (Monster monster in monsters)
        {
            playerTotalEnergy += monster.GetEnergyPoints();
        }
        return playerTotalEnergy;
    }
    
    public int GetPlayerEnergy()
    {
        return playerTotalEnergy;
    }

    public void SetPlayerEnergy(int newEnergy)
    {
        playerTotalEnergy = newEnergy;
        UpdatePlayerEnergyUI();
    }

    void UpdatePlayerEnergyUI()
    {
        playerEnergyUI.text = playerTotalEnergy.ToString();
    }
}
