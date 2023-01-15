using UnityEngine;
using UnityEngine.UI;

public class TotalTouchesText : MonoBehaviour
{
    [SerializeField] private Text totalTouchesText;

    public void SetTotalTouches(int totalTouches)
    {
        totalTouchesText.text = totalTouches.ToString();
    }
}