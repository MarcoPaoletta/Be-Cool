using UnityEngine;
using UnityEngine.UI;

public class LockedItemPanel : MonoBehaviour
{
    [SerializeField] private Text lockedItemText;

    public void ShowLockedItemPanel(int coolLevelNeeded)
    {
        gameObject.SetActive(true);
        lockedItemText.text = "cool level " + coolLevelNeeded + " needed"; 
    }
}