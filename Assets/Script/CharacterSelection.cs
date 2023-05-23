using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private Image imageCharacters;
    private int currentCharacter = 0;

    [SerializeField] private Sprite imageVirtualGuy;
    [SerializeField] private Sprite imagePinkMan;
    [SerializeField] private Sprite imageNinjaFrog;
    [SerializeField] private Sprite imageMaskDude;

    private Sprite[] sprites = new Sprite[4];
    private Color newColor = new Color(0.2f, 0.2f, 1f);
    private Color oldColor = new Color(0.2f, 1f, 0.4f);
    public Button oKButton;

    // Start is called before the first frame update
    void Start()
    {
        sprites[0] = imageVirtualGuy;
        sprites[1] = imagePinkMan;
        sprites[2] = imageNinjaFrog;
        sprites[3] = imageMaskDude;
        imageCharacters = GetComponentInChildren<Image>();
        //GameObject okSelectorObject = GameObject.Find("OKSelector");
        oKButton = GameObject.FindWithTag("OkButton").GetComponent<Button>();
    }
    //OKSelector

    private void Update()
    {
        if(PlayerPrefs.GetInt("characterIndex") == this.currentCharacter)
        {
            ColorBlock colors = oKButton.colors;
            colors.normalColor = newColor;
            oKButton.colors = colors;
        }
        else
        {
            ColorBlock colors = oKButton.colors;
            colors.normalColor = oldColor;
            oKButton.colors = colors;
        }
    }
    public void NextButton()
    {
        ChangeCurrentCharacter(this.currentCharacter + 1);
    }

    public void BackButton()
    {
        ChangeCurrentCharacter(this.currentCharacter - 1);
    }

    public void OKButton()
    {
        PlayerPrefs.SetInt("characterIndex", this.currentCharacter);
    }
    private int ClampCharacterValue(int value)
    {
        // If value is less than 0, set it to 3
        if (value < 0)
        {
            return 3;
        }

        // If value is greater than 3, set it to 0
        else if (value > 3)
        {
            return 0;
        }
        else
        {
            return value;
        }
    }

    private void ChangeCurrentCharacter(int currentCharacter)
    {
        this.currentCharacter = ClampCharacterValue(currentCharacter);
        imageCharacters.sprite = sprites[this.currentCharacter];
    }
}
