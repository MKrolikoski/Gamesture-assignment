using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShowTextButtonControl : MonoBehaviour
{
    public TMP_Text textToShowObject;
    public string textToShow;
    public float textShowDuration;

    protected Button button;
    protected float endingTime;
    protected bool textIsShown = false;


    private void Awake()
    {
        if(textToShowObject == null)
        {
            Debug.Log("[" + gameObject.name + "] TextToShow object not set.");
        }

        button = GetComponent<Button>();
    }
    private void Start()
    {
        button.onClick.AddListener(delegate { ShowText(); });
    }

    void Update()
    {
        if(textIsShown && Time.time >= endingTime)
        {
            ToggleText(false);
            button.interactable = true;
        }
    }

    protected void ToggleText(bool textEnabled)
    {
        textToShowObject.enabled = textEnabled;
        textIsShown = textEnabled;
    }

    public void ShowText()
    {
        endingTime = Time.time + textShowDuration;
        textToShowObject.text = textToShow;
        ToggleText(true);
        button.interactable = false;
    }
}
