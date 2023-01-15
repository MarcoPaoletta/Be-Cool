using UnityEngine;
using UnityEngine.UI;

public class LevelCompletedPanel : MonoBehaviour
{
    [HideInInspector] public bool isLevelCompletedPanelShowing;

    [SerializeField] private Text levelCompletedText;
    [SerializeField] private Button CloseLevelCompletedButton;

    public void ShowLevelCompletedPanel()
    {
        gameObject.SetActive(true);
        levelCompletedText.text = "New cool level";;
        isLevelCompletedPanelShowing = true;
        SetCloseLevelCompletedButtonPosition();
    }

    private void SetCloseLevelCompletedButtonPosition()
    {
        float panelWidth = GetComponent<RectTransform>().rect.width;
        float panelHeight = GetComponent<RectTransform>().rect.height;

        float minX = -panelWidth;
        float maxX = panelWidth;
        float minY = -panelHeight;
        float maxY = panelHeight;

        float randomX = Random.Range(60, maxX - 60);
        float randomY = Random.Range(-60, minY);

        CloseLevelCompletedButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(randomX, randomY, 0);
    }

    public void OnCloseLevelCompletedButtonClicked()
    {
        isLevelCompletedPanelShowing = false;
    }
}