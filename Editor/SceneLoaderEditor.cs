using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Thimas.SceneManagement;

[CustomEditor(typeof(SceneLoader))]
public class SceneLoaderEditor : Editor
{
    public VisualTreeAsset VisualTree;

    Button _button1;
    Button _button2;

    PropertyField _showButtonsProperty;
    VisualElement _itemsToHideContainer;
    SerializedProperty _boolProperty;

    SceneLoader _sceneLoader;

    private void OnEnable()
    {
        _sceneLoader = (SceneLoader)target;
        _boolProperty = serializedObject.FindProperty("_showButtons");
    }

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new();

        // Adds all the UI Builder Stuff
        VisualTree.CloneTree(root);

        _button1 = root.Q<Button>("Load1");
        _button2 = root.Q<Button>("Load2");
        _showButtonsProperty = root.Q<PropertyField>("ToggleBool");
        _itemsToHideContainer = root.Q<VisualElement>("ItemsToHideContainer");

        _button1.RegisterCallback<ClickEvent>((n) => _sceneLoader.LoadSceneGroup1());
        _button2.RegisterCallback<ClickEvent>((n) => _sceneLoader.LoadSceneGroup2());
        _showButtonsProperty.RegisterCallback<ChangeEvent<bool>>((n) => CheckforDisplayType());

        CheckforDisplayType();

        return root;
    }

    void CheckforDisplayType()
    {
        if (_boolProperty.boolValue)
        {
            // SHOW
            _itemsToHideContainer.style.display = DisplayStyle.Flex;
        }
        else
        {
            // HIDE
            _itemsToHideContainer.style.display = DisplayStyle.None;
        }
    }
}
