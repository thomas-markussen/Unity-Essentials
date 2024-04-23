﻿using UnityEditor;
using UnityEngine;

namespace Thimas.DependencyInjection {
    [CustomPropertyDrawer(typeof(InjectAttribute))]
    public class InjectPropertyDrawer : PropertyDrawer {
        Texture2D icon;

        Texture2D LoadIcon() {
            if (icon == null) {
                icon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/UnityEssentials/Editor/DependencyInjection/icon.png");
            }

            return icon;
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            icon = LoadIcon();
            var iconRect = new Rect(position.x, position.y, 20, 20);
            position.xMin += 24;

            if (icon != null) {
                var savedColor = GUI.color;
                GUI.color = property.objectReferenceValue == null ? savedColor : Color.green;
                GUI.DrawTexture(iconRect, icon);
                GUI.color = savedColor;
            }
            
            EditorGUI.PropertyField(position, property, label);
        }
    }
}