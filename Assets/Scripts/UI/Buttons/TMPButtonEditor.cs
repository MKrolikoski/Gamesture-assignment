using UnityEditor;

[CustomEditor(typeof(TMPButton))]
public class TMPButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TMPButton targetButton = (TMPButton)target;
    }
}
