using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackButton : MonoBehaviour
{
    public void OnGoBackButtonClicked()
    {
        AudioManager.PlayButtonClickedAudio();
        SceneManager.LoadScene("Main");
    }
}