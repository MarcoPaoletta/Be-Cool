using UnityEngine;

public class CloseWindowButton : MonoBehaviour
{
    public void OnCloseWindowButtonClicked(GameObject window)
    {
        AudioManager.PlayButtonClickedAudio();
        window.SetActive(false);
    }
}