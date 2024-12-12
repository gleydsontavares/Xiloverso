using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xilo : MonoBehaviour
{
    // Start is called before the first frame update
    public int Number;

    public string Name;

    public Size size;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private Sprite[] spriteSheet;

    public Power power1;

    public Power power2;

    public Archetype archetype;

    public int maxHP;
    public int stamina;
    public int speed;
    public Gift gift;
    private string giftName;
    private string giftDescription;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        giftName = Dictionaries.GetGift(gift);
        giftDescription = Dictionaries.GetGiftDescription(gift);

        Debug.Log($"{giftName}: {giftDescription}");
    }

    void Start() { }

    // Update is called once per frame
    void Update() { }
}
