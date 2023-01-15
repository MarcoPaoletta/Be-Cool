using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class ShopManager : MonoBehaviour
{
    [HideInInspector] public int selectedEmojiButtonIndex;
    [HideInInspector] public List<int> availableEmojisIndexes = new List<int>();
    [HideInInspector] public int selectedHatButtonIndex;
    [HideInInspector] public List<int> availableHatsIndexes = new List<int>();
    [HideInInspector] public int sprite1IndexTemp;
    [HideInInspector] public int sprite2IndexTemp;
    [HideInInspector] public int hatIndexTemp;

    [SerializeField] private LockedItemPanel lockedItemPanelScript;
    [SerializeField] private GameObject emojisGrid;
    [SerializeField] private GameObject hatsGrid;
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite paper;

    private Color defaultButtonColor;
    private GameObject[] emojis;
    private List<Button> emojisButtons = new List<Button>();
    private List<Image> emojisButtonImages = new List<Image>();
    private GameObject[] hats;
    private List<Button> hatsButtons = new List<Button>();
    private List<Image> hatsButtonImages = new List<Image>();

    private void Start()
    {
        availableEmojisIndexes.Add(0);
        availableHatsIndexes.Add(0);

        if(SaveAndLoadShopManager.LoadShopManager() == null)
        {
            SaveAndLoadShopManager.SaveShopManager(this);
            LoadData();
        }
        else
        {
            LoadData();
        }

        AssignVariables();
        CheckCoolLevel();
        CheckBoughtItems();
        SetSelectedEmojiButtonColor();
        SetSelectedHatButtonColor();
        AddEmojiButtonsListeners();
        AddHatButtonsListeners();
    }

    private void LoadData()
    {
        ShopData shopData = SaveAndLoadShopManager.LoadShopManager();
        selectedEmojiButtonIndex = shopData.selectedEmojiButtonIndex;
        availableEmojisIndexes = shopData.availableEmojisIndexes; 
        selectedHatButtonIndex = shopData.selectedHatButtonIndex;
        availableHatsIndexes = shopData.availableHatsIndexes;
        sprite1IndexTemp = shopData.sprite1IndexTemp;
        sprite2IndexTemp = shopData.sprite2IndexTemp;
        hatIndexTemp = shopData.hatIndexTemp;
    }

    private void AssignVariables()
    {
        defaultButtonColor = emojisGrid.transform.Find("Button0").GetComponent<Image>().color;
        emojis = GameObject.FindGameObjectsWithTag("EmojiButton");

        foreach (var emoji in emojis)
        {
            emojisButtons.Add(emoji.GetComponent<Button>());
            emojisButtonImages.Add(emoji.GetComponent<Image>());
        }

        hats = GameObject.FindGameObjectsWithTag("HatButton");

        foreach (var hat in hats)
        {
            hatsButtons.Add(hat.GetComponent<Button>());
            hatsButtonImages.Add(hat.GetComponent<Image>());
        }
    }

    private void CheckCoolLevel()
    {
        PlayerData playerData = SaveAndLoadManager.LoadPlayer();
        int coolLevel = playerData.level;

        if(coolLevel >= 10)
        {
            availableEmojisIndexes.Add(1);
        } 
        if(coolLevel >= 15)
        {
            availableHatsIndexes.Add(1);
        }       
        if(coolLevel >= 20)
        {
            availableEmojisIndexes.Add(2);
        }        
        if(coolLevel >= 30)
        {
            availableEmojisIndexes.Add(3);
            availableHatsIndexes.Add(2);
        }        
        if(coolLevel >= 40)
        {
            availableEmojisIndexes.Add(4);
        }   
        if(coolLevel >= 45)
        {
            availableHatsIndexes.Add(3);
        }     
        if(coolLevel >= 50)
        {
            availableEmojisIndexes.Add(5);
        }      
        if(coolLevel >= 60)
        {
            availableHatsIndexes.Add(4);
        }
        if(coolLevel >= 75)
        {
            availableHatsIndexes.Add(5);
        }
    }



    private void CheckBoughtItems()
    {    
        foreach (var button in emojisButtons)
        {
            foreach (var index in availableEmojisIndexes)
            {
                if(button.name == "Button" + index)
                {
                    GameObject boughtButton = emojisGrid.transform.Find("Button" + index).gameObject;

                    boughtButton.GetComponent<Image>().sprite = paper;

                    Image boughtButtonImage = boughtButton.transform.Find("Image").GetComponent<Image>();
                    Color tempColor = boughtButtonImage.color;
                    tempColor.a = 1f;
                    boughtButtonImage.color = tempColor;
                }
            }
        }

        foreach (var button in hatsButtons)
        {
            foreach (var index in availableHatsIndexes)
            {
                if(button.name == "Button" + index)
                {
                    GameObject boughtButton = hatsGrid.transform.Find("Button" + index).gameObject;

                    boughtButton.GetComponent<Image>().sprite = paper;

                    Image boughtButtonImage = boughtButton.transform.Find("Image").GetComponent<Image>();
                    Color tempColor = boughtButtonImage.color;
                    tempColor.a = 1f;
                    boughtButtonImage.color = tempColor;  
                }
            }
        }
    }

    private void SetSelectedEmojiButtonColor()
    {
        Image selectedEmojiButtonImage = emojisGrid.transform.Find("Button" + selectedEmojiButtonIndex).GetComponent<Image>();
        selectedEmojiButtonImage.color = Color.green;
    }

    private void SetSelectedHatButtonColor()
    {
        Image selectedHatButtonImage = hatsGrid.transform.Find("Button" + selectedHatButtonIndex).GetComponent<Image>();
        selectedHatButtonImage.color = Color.green;        
    }

    private void AddEmojiButtonsListeners()
    {
        foreach (var button in emojisButtons)
        {
            button.onClick.AddListener(delegate{OnEmojiButtonClicked(button.gameObject);});
        }
    }

    private void AddHatButtonsListeners()
    {
        foreach (var button in hatsButtons)
        {
            button.onClick.AddListener(delegate{OnHatButtonClicked(button.gameObject);});
        }
    }

    private void OnEmojiButtonClicked(GameObject button)
    {
        AudioManager.PlayButtonClickedAudio();
        selectedEmojiButtonIndex = int.Parse(button.name.Replace("Button", ""));
        
        foreach (var index in availableEmojisIndexes)
        {
            if(button.name == "Button" + index)
            {
                ResetEmojisButtonsColor();
                SetSelectedEmojiButtonColor();

                switch (selectedEmojiButtonIndex)
                {
                    case 0:
                        SetPlayerSpriteIndexes(0, 1);
                        break;
                    case 1:
                        SetPlayerSpriteIndexes(2, 3);
                        break;
                    case 2:
                        SetPlayerSpriteIndexes(4, 5);
                        break;
                    case 3:
                        SetPlayerSpriteIndexes(6, 7);
                        break;
                    case 4:
                        SetPlayerSpriteIndexes(8, 9);
                        break;
                    case 5:
                        SetPlayerSpriteIndexes(10, 11);
                        break;
                }
                return;
            }
        }

        if(button.GetComponent<Image>().color != Color.green)
        {
            int coolLevelNeeded = selectedEmojiButtonIndex * 10;
            lockedItemPanelScript.ShowLockedItemPanel(coolLevelNeeded);
        }
    }

    private void ResetEmojisButtonsColor()
    {
        foreach(var buttonImage in emojisButtonImages)
        {
            buttonImage.color = defaultButtonColor;
        }
    }

    private void SetPlayerSpriteIndexes(int sprite1Index, int sprite2Index)
    {
        Player playerScript = player.GetComponent<Player>();
        sprite1IndexTemp = sprite1Index;
        sprite2IndexTemp = sprite2Index;
        playerScript.SavePlayerData(sprite1IndexTemp, sprite2IndexTemp, hatIndexTemp);
        availableEmojisIndexes.Add(selectedEmojiButtonIndex);
        SaveAndLoadShopManager.SaveShopManager(this);
    }

    private void OnHatButtonClicked(GameObject button)
    {
        AudioManager.PlayButtonClickedAudio();
        selectedHatButtonIndex = int.Parse(button.name.Replace("Button", ""));

        foreach (var index in availableHatsIndexes)
        {
            if(button.name == "Button" + index)
            {
                ResetHatsButtonsColor();
                SetSelectedHatButtonColor();
                SetHatIndex(selectedHatButtonIndex);
                return;
            }
        }

        if(button.GetComponent<Image>().color != Color.green)
        {
            int coolLevelNeeded = selectedHatButtonIndex * 15;
            lockedItemPanelScript.ShowLockedItemPanel(coolLevelNeeded);
        }
    }

    private void ResetHatsButtonsColor()
    {
        foreach(var buttonImage in hatsButtonImages)
        {
            buttonImage.color = defaultButtonColor;
        }
    }

    private void SetHatIndex(int hatIndex)
    {
        Player playerScript = player.GetComponent<Player>();
        hatIndexTemp = hatIndex;
        playerScript.SavePlayerData(sprite1IndexTemp, sprite2IndexTemp, hatIndexTemp);
        availableHatsIndexes.Add(selectedHatButtonIndex);
        SaveAndLoadShopManager.SaveShopManager(this);
    }
}