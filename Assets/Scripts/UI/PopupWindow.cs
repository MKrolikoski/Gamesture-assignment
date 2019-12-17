using UnityEngine;
using UnityEngine.UI;

public class PopupWindow : MonoBehaviour
{
    public Button closeButton;
    public event System.Action OnWindowClosed;

    private void Start()
    {
        if(closeButton != null)
        {
            closeButton.onClick.AddListener(delegate { CloseWindow(); });
        }
        else
        {
            Debug.Log("[" + gameObject.name + "] close button not set.");
        }
    }

    public void CloseWindow()
    {
        OnWindowClosed?.Invoke();
        Destroy(gameObject);
    }
}
