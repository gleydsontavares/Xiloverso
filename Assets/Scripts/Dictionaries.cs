using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dictionaries", order = 1)]
public class Dictionaries : ScriptableObject
{
    private static readonly Dictionary<string, string> giftsDescriptions =
        new()
        {
            {
                "Espírito de Equipe",
                "Quando a vida da equipe chegar em 25% ou menos, a próxima carta a ser usada por este Xilo que for do seu tipo não tem custo"
            },
            {
                "Amigo Fiel",
                "Quando um aliado adjacente atacar, há 10% de chance de o ataque ser crítico"
            },
            { "Invulnerável", "O Xilo recebe Invulnerabilidade assim que entra em campo." },
            {
                "Néctar da Vida",
                "Toda vez que este Xilo atacar o time se cura em 20% do dano que ele causar"
            },
            {
                "Estática",
                "Quando um inimigo usa um ataque com Poder de Luz contra o time em que este Xilo está, o usuário do ataque tem 50% de chance de receber Paralisia"
            },
            {
                "Absorção de água",
                "Quando um inimigo usa um ataque com Poder de Água contra o time em que este Xilo está, o dano é reduzido em 1/3"
            },
            { "Centro das atenções", "Atrair carta de status" },
            { "Presença Ameaçadora", "Todo turno este Xilo causa 1 de dano ao time inimigo" }
        };

    private static readonly Dictionary<Gift, string> gifts =
        new()
        {
            { Gift.NONE, "" },
            { Gift.TEAMSPIRIT, "Espírito de Equipe" },
            { Gift.LOYALFRIEND, "Amigo Fiel" },
            { Gift.INVULNERABLE, "Invulnerável" },
            { Gift.NECTAROFLIFE, "Néctar da Vida" },
            { Gift.STATIC, "Estática" },
            { Gift.WATERABSORBTION, "Absorção de água" },
            { Gift.MAINSTAR, "Centro das atenções" },
            { Gift.FRIGHTENINGPRESENCE, "Presença Ameaçadora" }
        };

    public static string GetGift(Gift gift)
    {
        return gifts[gift];
    }

    public static string GetGiftDescription(Gift gift)
    {
        return giftsDescriptions[gifts[gift]];
    }
}
