using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [HideInInspector] public int score;
    [HideInInspector] public int level;
    [HideInInspector] public int touchesLeft;
    [HideInInspector] public int totalTouches;
    [HideInInspector] public int sprite1Index;
    [HideInInspector] public int sprite2Index;
    [HideInInspector] public int hatIndex;

    [Header("Scripts")]
    [SerializeField] private TouchesLeftText touchesLeftTextScript;
    [SerializeField] private LevelText levelTextScript;
    [SerializeField] private LevelCompletedPanel levelCompletedPanelScript;
    [SerializeField] private TotalTouchesText totalTouchesTextScript;

    [Space]

    [SerializeField] private GameObject touchParticles;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Lists")]
    [SerializeField] private List<Sprite> spriteSheetSprites = new List<Sprite>();
    [SerializeField] private List<GameObject> hats = new List<GameObject>();

    private void Start()
    {
        if(SaveAndLoadManager.LoadPlayer() == null)
        {
            SaveAndLoadManager.SavePlayer(this);
            LoadData();
        }
        else
        {
            LoadData();
        }

        SetHat();
        SetTouchesLeft();
    }

    private void LoadData()
    {
        PlayerData playerData = SaveAndLoadManager.LoadPlayer();
        level = playerData.level;
        score = playerData.score;
        touchesLeft = playerData.touchesLeft;
        totalTouches = playerData.totalTouches;
        sprite1Index = playerData.sprite1Index;
        sprite2Index = playerData.sprite2Index;
        hatIndex = playerData.hatIndex;

        if(level == 0)
        {
            level = 1;
        }
        if(touchesLeft == 0)
        {
            touchesLeft = 1;
        }

        totalTouchesTextScript.SetTotalTouches(totalTouches);
        levelTextScript.SetLevelText(level);
        spriteRenderer.sprite = spriteSheetSprites[sprite1Index];
    }

    private void SetHat()
    {
        if(hatIndex != 0)
        {
            GameObject selectedHat = transform.Find("Hat" + hatIndex).gameObject;
            selectedHat.SetActive(true);
        }
    }

    private void OnMouseUp()
    {
        if (!levelCompletedPanelScript.isLevelCompletedPanelShowing)
        {
            score += 1;
            totalTouches += 1;
            totalTouchesTextScript.SetTotalTouches(totalTouches);
            ShowTouchParticles();
            AudioManager.PlayScoredAudio();

            if (isLevelCompleted())
            {
                level += 1;
                score = 0;
                levelTextScript.SetLevelText(level);
                levelCompletedPanelScript.ShowLevelCompletedPanel();
            }

            SetTouchesLeft();
            spriteRenderer.color = Color.white;
            spriteRenderer.sprite = spriteSheetSprites[sprite1Index];
            SaveAndLoadManager.SavePlayer(this);
        }
    }

    private void ShowTouchParticles()
    {
        Instantiate(touchParticles, touchParticles.transform.position, Quaternion.identity);
    }

    private void OnMouseDown()
    {
        spriteRenderer.sprite = spriteSheetSprites[sprite2Index];

        if (!levelCompletedPanelScript.isLevelCompletedPanelShowing)
        {
            spriteRenderer.color = Color.gray;
            
        }
        if (levelCompletedPanelScript.isLevelCompletedPanelShowing)
        {
            spriteRenderer.sprite = spriteSheetSprites[sprite1Index];
        }
    }

    private bool isLevelCompleted()
    {
        if (score >= level)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetTouchesLeft()
    {
        touchesLeft = level - score;
        touchesLeftTextScript.SetTouchesLeftText(touchesLeft);
    }

    public void SavePlayerData(int sprite1IndexTemp, int sprite2IndexTemp, int hatIndexTemp)
    {
        PlayerData playerData = SaveAndLoadManager.LoadPlayer();
        score = playerData.score;
        level = playerData.level;
        touchesLeft = playerData.touchesLeft;
        totalTouches = playerData.totalTouches;
        sprite1Index = sprite1IndexTemp;
        sprite2Index = sprite2IndexTemp;
        hatIndex = hatIndexTemp;
        SaveAndLoadManager.SavePlayer(this);
    }
}