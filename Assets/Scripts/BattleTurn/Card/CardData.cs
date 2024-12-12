using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
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

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public int cardNumber;
    public int cardEnergy;
    public string cardDescription;
    public CardType cardType;

}
