using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardData cardData;

    public TMP_Text cardNumberText;
    public TMP_Text cardNameText;
    public TMP_Text cardDescriptionText;
    public Image cardImage;
    public TMP_Text cardEnergyText;

    private CardManager cardManager;
    

    void Start()
    {
        cardNumberText.text = cardData.cardNumber.ToString();
        cardNameText.text = cardData.cardName;
        cardDescriptionText.text = cardData.cardDescription;
        cardImage.sprite = cardData.cardImage;
        cardEnergyText.text = cardData.cardEnergy.ToString();

        cardManager = FindObjectOfType<CardManager>();
    }

    public void OnClickCard()
    {
        if(cardManager != null)
        {
            cardManager.UseCard(this);
            Debug.Log($"{cardData.cardName} foi usada.");
        }
        else
        {
            Debug.LogError("CardManager não encontrado!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Botão direito do mouse
        {
            CardManager cardManager = FindObjectOfType<CardManager>();
            cardManager.ShowZoomedCard(cardData);
        }
    }

    void OnMouseOver()
    {
        // Detecta o clique com o botão direito do mouse
        if (Input.GetMouseButtonDown(1)) // 1 = botão direito do mouse
        {
            if (cardManager != null)
            {
                CardManager cardManager = FindObjectOfType<CardManager>();
                cardManager.ShowZoomedCard(cardData);
            }
        }
    }
}
