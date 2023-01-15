using UnityEngine;
using UnityEngine.UI;

public class TouchesLeftText : MonoBehaviour
{
    [SerializeField] private Text touchesLeftText;

    public void SetTouchesLeftText(int touchesLeft)
    {
        touchesLeftText.text = "taps left: " + touchesLeft;
    }
}