using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PopupButtonControl : MonoBehaviour
{
    public Image popupWindow;
    public Canvas ui;

    protected Button button;
    protected GameObject popupWindowInstance;

    private void Awake()
    {
        button = GetComponent<Button>();

        // If UI object is not set, searches for main UI canvas for later popup window parenting
        if (ui == null)
        {
            foreach (Canvas canvas in FindObjectsOfType<Canvas>())
            {
                if(canvas.name.ToLower().Equals("ui"))
                {
                    ui = canvas;
                    break;
                }
            }
        }
    }
    private void Start()
    {
        button.onClick.AddListener(delegate { OpenPopupWindow(); });
    }


    public void OpenPopupWindow()
    {
        popupWindowInstance = Instantiate(popupWindow, ui.transform).gameObject;
        popupWindowInstance.name = "PopupWindow";
        popupWindowInstance.GetComponent<PopupWindow>().OnWindowClosed += OnPopupWindowClosed;
        button.interactable = false;
    }

    protected void OnPopupWindowClosed()
    {
        button.interactable = true;
    }
}
