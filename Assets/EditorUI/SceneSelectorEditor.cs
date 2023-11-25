using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class SceneSelectorEditor : EditorWindow
{
    [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;
    private static SceneSelectorEditor wnd;

    [MenuItem("Window/UI Toolkit/SceneSelectorEditor")]
    public static void ShowExample()
    {
        wnd = GetWindow<SceneSelectorEditor>();
        wnd.titleContent = new GUIContent("SceneSelectorEditor");
    }

    public void CreateGUI()
    {
        m_VisualTreeAsset.CloneTree(rootVisualElement);
        var sceneView = rootVisualElement.Q<ListView>("#scenes");
        var directoryView = rootVisualElement.Q<ListView>("directory");

        // directoryView.itemsSource = searchFolder;
        directoryView.makeItem = () => new Button();
        directoryView.bindItem = (element, i) =>
        {

        };
        
        // sceneView.itemsSource = scenePathToName[_activeTab];
        sceneView.makeItem = () => new Button();
        sceneView.bindItem = (element, i) =>
        {
        };
    }

    private void OnSceneButtonClicked(string path)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(path);
            if (wnd != null) wnd.Close();
        }
    }
}