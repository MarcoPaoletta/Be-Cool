using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopData
{
    public int selectedEmojiButtonIndex;
    public List<int> availableEmojisIndexes = new List<int>();
    public int selectedHatButtonIndex;
    public List<int> availableHatsIndexes = new List<int>();
    public int sprite1IndexTemp;
    public int sprite2IndexTemp;
    public int hatIndexTemp;


    public ShopData(ShopManager shopManager)
    {
        selectedEmojiButtonIndex = shopManager.selectedEmojiButtonIndex;
        availableEmojisIndexes = shopManager.availableEmojisIndexes;
        selectedHatButtonIndex = shopManager.selectedHatButtonIndex;
        availableHatsIndexes = shopManager.availableHatsIndexes;
        sprite1IndexTemp = shopManager.sprite1IndexTemp;
        sprite2IndexTemp = shopManager.sprite2IndexTemp;
        hatIndexTemp = shopManager.hatIndexTemp;
    }
}