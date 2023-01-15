using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    [SerializeField] private Text levelText;

    public void SetLevelText(int level)
    {
        levelText.text = "Cool level: " + level;
    }
}