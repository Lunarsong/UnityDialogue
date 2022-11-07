using Graph;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using GraphEditor = Graph.GraphEditor;

public class DialogueEditorWindow : EditorWindow
{
    [SerializeField]
    GraphAsset m_Asset;
    public GraphAsset Asset
    {
        get => m_Asset;
        set
        {
            m_Asset = value;
            if (m_GraphEditor.Asset != value)
            {
                m_GraphEditor.Asset = value;
            }
            titleContent.text = m_Asset.name;
        }
    }
    GraphEditor m_GraphEditor;

    private void OnEnable()
    {
        this.SetAntiAliasing(8);
        titleContent = new GUIContent("Dialogue Editor");
        m_GraphEditor = new GraphEditor();
        rootVisualElement.Add(m_GraphEditor);
        if (Asset != null)
        {
            m_GraphEditor.Asset = Asset;
        }
        else
        {
            Asset = CreateInstance<GraphAsset>();
        }
    }

    [MenuItem("Game/Dialogue Editor")]
    static void OpenWindow()
    {
        // Get existing open window or if none, make a new one:
        DialogueEditorWindow window = GetWindow<DialogueEditorWindow>("Dialogue Editor", true);
        window.Show();
    }
}
