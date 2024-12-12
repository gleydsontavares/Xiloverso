using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    Amarelo,
    Azul,
    Vermelho,
    Verde,
    Ciano,
    Dourado,
    Roxo,
    Rosa,
    Cinza
}

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]

public class MonsterData : ScriptableObject
{
    public string monsterName;
    public int maxHP;
    public int currentHP;
    public int energyPoints;
    public int speed;
    public MonsterType type;

}
