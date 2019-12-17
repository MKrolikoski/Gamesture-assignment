using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TMPButton : Button
{
    public TMP_ColorGradient mainGradient;
    public TMP_ColorGradient highlightedGradient;
    public TMP_ColorGradient selectedGradient;
    public TMP_ColorGradient disabledGradient;

    protected TMP_Text buttonText;

    protected override void Awake()
    {
        base.Awake();

        buttonText = GetComponentInChildren<TMP_Text>();

        #region gradient_null_check
        if (mainGradient == null)
        {
            Debug.Log("["+ gameObject.name + "] mainGradient not assigned.");
        }
        if(highlightedGradient == null)
        {
            Debug.Log("[" + gameObject.name + "] highlightedGradient not assigned.");

        }
        if (selectedGradient == null)
        {
            Debug.Log("[" + gameObject.name + "] selectedGradient not assigned.");

        }
        if (disabledGradient == null)
        {
            Debug.Log("[" + gameObject.name + "] disabledGradient not assigned.");

        }
        #endregion

        if (buttonText == null)
        {
            Debug.Log("[" + gameObject.name + "] No TextMeshPro text assigned to button.");
        }
        else
        {
            AssignGradient(mainGradient);
        }
    }
    

    protected void AssignGradient(TMP_ColorGradient gradient)
    {
        if(buttonText != null)
        {
            buttonText.colorGradientPreset = gradient;
        }
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        switch (state)
        {
            case Selectable.SelectionState.Normal:
                AssignGradient(mainGradient);
                break;
            case Selectable.SelectionState.Highlighted:
                AssignGradient(highlightedGradient);
                break;
            case Selectable.SelectionState.Pressed:
                break;
            case Selectable.SelectionState.Selected:
                AssignGradient(selectedGradient);
                break;
            case Selectable.SelectionState.Disabled:
                AssignGradient(disabledGradient);
                break;
            default:
                AssignGradient(mainGradient);
                break;
        }
    }
}
