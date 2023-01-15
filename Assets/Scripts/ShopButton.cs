using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    public void OnShopButtonClicked()
    {
        AudioManager.PlayButtonClickedAudio();
        SceneManager.LoadScene("Shop");
    }
}