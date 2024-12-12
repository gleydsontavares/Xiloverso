using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct CardPrefabMapping
{
    public CardType cardType;
    public GameObject prefab;
}

[System.Serializable]
public struct CardTypeImageMapping
{
    public CardType cardType;
    public Sprite typeImage;
}

public class CardManager : MonoBehaviour
{
    public List<CardData> availableCards;
    public Transform cardParent;
    public TMP_Text playerEnegyText;

    public List<CardPrefabMapping> cardPrefabMappings;
    private Dictionary<CardType, GameObject> cardPrefabs = new Dictionary<CardType, GameObject>();

    private BattleManager battleManager;
    private int playerEnergy;
    private HashSet<int> drawnCards = new HashSet<int>();

    public GameObject zoomedCardPanel; // Painel para exibir a carta ampliada
    public Image zoomedCardImage;// Imagem da carta ampliada
    public TMP_Text zoomedCardName;
    public TMP_Text zoomedCardDescription;
    public TMP_Text zoomedCardEnergy;
    public TMP_Text zoomedCardNumber;

    public List<CardTypeImageMapping> cardTypeImageMappings;
    private Dictionary<CardType, Sprite> typeImages = new Dictionary<CardType, Sprite>();

    public Image zoomedCardTypeImage; // Referência à imagem no painel de zoom


    void Start()
    {
        foreach (var mapping in cardPrefabMappings)
        {
            if (mapping.prefab != null)
            {
                cardPrefabs[mapping.cardType] = mapping.prefab;
            }
            else
            {
                Debug.LogError($"Prefab para {mapping.cardType} não está atribuído!");
            }
        }

        foreach (var mapping in cardTypeImageMappings)
        {
            if (mapping.typeImage != null)
            {
                typeImages[mapping.cardType] = mapping.typeImage;
            }
            else
            {
                Debug.LogError($"Imagem para {mapping.cardType} não está atribuída!");
            }
        }

        battleManager = FindObjectOfType<BattleManager>();
        playerEnergy = battleManager.GetPlayerEnergy();

        DrawCards();
    }

    void DrawCards()
    {
        while (drawnCards.Count < 5)
        {
            int randomIndex = Random.Range(0, availableCards.Count);

            if (!drawnCards.Contains(randomIndex))
            {
                drawnCards.Add(randomIndex);

                CardData cardData = availableCards[randomIndex];
                GameObject prefabToInstantiate = GetCardPrefab(cardData.cardType);

                if (prefabToInstantiate == null)
                {
                    Debug.LogError($"Erro ao tentar instanciar a carta. Prefab do tipo {cardData.cardType} está ausente.");
                    continue;
                }

                GameObject cardObject = Instantiate(prefabToInstantiate, cardParent);
                Card card = cardObject.GetComponent<Card>();
                card.cardData = cardData;
            }
        }
    }

    GameObject GetCardPrefab(CardType cardType)
    {
        if (cardPrefabs.ContainsKey(cardType))
        {
            return cardPrefabs[cardType];
        }

        Debug.LogWarning($"Prefab não atribuído para o tipo de carta: {cardType}. Certifique-se de configurar o prefab no Inspector.");
        return null;
    }

    public void UseCard(Card card)
    {
        // Verifica se há energia suficiente para usar a carta
        if (playerEnergy >= card.cardData.cardEnergy)
        {
            playerEnergy -= card.cardData.cardEnergy; // Subtrai a energia
            battleManager.SetPlayerEnergy(playerEnergy); // Atualiza a energia no BattleManager

            Debug.Log($"Carta {card.cardData.cardName} usada. Energia restante: {playerEnergy}");

            Destroy(card.gameObject); // Destrói a carta usada

            // Adiciona uma nova carta, se possível
            if (drawnCards.Count < availableCards.Count)
            {
                DrawNewCard();
            }
        }
        else
        {
            Debug.LogError("Energia insuficiente para usar esta carta!");
        }
    }

    void DrawNewCard()
    {
        if (availableCards.Count == 0)
        {
            Debug.LogError("Nenhuma carta disponível para desenhar.");
            return;
        }

        int randomIndex;
        do
        {
            randomIndex = Random.Range(0, availableCards.Count);
        } while (drawnCards.Contains(randomIndex));

        drawnCards.Add(randomIndex);

        CardData cardData = availableCards[randomIndex];
        GameObject prefabToInstantiate = GetCardPrefab(cardData.cardType);

        if (prefabToInstantiate == null)
        {
            Debug.LogError($"Prefab para o tipo de carta {cardData.cardType} não foi encontrado.");
            return;
        }

        GameObject cardObject = Instantiate(prefabToInstantiate, cardParent);
        Card card = cardObject.GetComponent<Card>();
        card.cardData = cardData;
    }

    public void ShowZoomedCard(CardData cardData)
    {
        zoomedCardPanel.SetActive(true); // Exibe o painel ampliado

        // Atualiza os elementos visuais com os dados da carta
        zoomedCardImage.sprite = cardData.cardImage;
        zoomedCardName.text = cardData.cardName;
        zoomedCardDescription.text = cardData.cardDescription;
        zoomedCardEnergy.text = cardData.cardEnergy.ToString();
        zoomedCardNumber.text = cardData.cardNumber.ToString();

        // Atualiza a imagem de tipo com base no cardType
        if (typeImages.ContainsKey(cardData.cardType))
        {
            zoomedCardTypeImage.sprite = typeImages[cardData.cardType];
        }
        else
        {
            Debug.LogWarning($"Imagem para o tipo de carta {cardData.cardType} não encontrada!");
            zoomedCardTypeImage.sprite = null; // Opcional: sprite padrão
        }
    }
    public void HideZoomedCard()
    {
        zoomedCardPanel.SetActive(false); // Esconde o painel ampliado
    }
}
