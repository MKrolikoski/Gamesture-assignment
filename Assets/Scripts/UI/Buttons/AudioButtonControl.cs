using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioButtonControl : MonoBehaviour
{
    public string soundName;
    public Button stopPlayingButton;

    protected Button playButton;

    private void Awake()
    {
        if (stopPlayingButton == null)
        {
            Debug.Log("[" + gameObject.name + "] stopPlayingButton not assigned.");
        }

        playButton = GetComponent<Button>();
    }
    private void Start()
    {
        stopPlayingButton.onClick.AddListener(delegate { ToggleSound(false); });
        stopPlayingButton.interactable = false;
        playButton.onClick.AddListener(delegate { ToggleSound(true); });
    }


    public void ToggleSound(bool toggle)
    {
        if(toggle)
        {
            AudioManager.instance.PlayClip(soundName);
            stopPlayingButton.interactable = true;
        }
        else
        {
            AudioManager.instance.StopClip(soundName);
            stopPlayingButton.interactable = false;
        }
    }

    
}
