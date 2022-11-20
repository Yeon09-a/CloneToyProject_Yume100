using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour
{
    public TextMeshProUGUI chaName;
    public Image color;
    public Image characterImage;
    public Image stars;
    public TextMeshProUGUI hp;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI heal;

    public void SetCharacterPanel(string name, Sprite color, Sprite characterImage, Sprite stars, int hp, int attack, int heal)
    {
        chaName.text = name;
        this.color.sprite = color;
        this.characterImage.sprite = characterImage;
        this.stars.sprite = stars;
        this.hp.text = hp.ToString();
        this.attack.text = attack.ToString();
        this.heal.text = heal.ToString();
    }
}
