using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource scoredAudio;
    private AudioSource buttonClickedAudio;

    private void Awake()
    {
        if(AudioManager.instance == null)
        {
            AudioManager.instance = this;
            DontDestroyOnLoad(gameObject);
            scoredAudio = transform.Find("ScoredAudio").GetComponent<AudioSource>();
            buttonClickedAudio = transform.Find("ButtonClickedAudio").GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void PlayScoredAudio()
    {
        instance.scoredAudio.Play();
    }

    public static void PlayButtonClickedAudio()
    {
        instance.buttonClickedAudio.Play();
    }
}