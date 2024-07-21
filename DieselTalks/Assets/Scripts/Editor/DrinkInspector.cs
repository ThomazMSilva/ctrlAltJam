using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/*
[CustomEditor(typeof(Drink)), CanEditMultipleObjects]
public class DrinkInspector : Editor
{

    private Flavour flavourEnum = Flavour.sour;
    float flavourValue = 0;

    private SerializedProperty onCustomButtonPressed;
    private SerializedProperty onModify;
    private SerializedObject so;

    private void OnEnable()
    {
        so = serializedObject;
        onCustomButtonPressed = so.FindProperty("OnCustomButtonPressed");
        onModify = so.FindProperty("OnModify");
    }

    public override void OnInspectorGUI()
    {*//*
        so.Update();

        
        EditorGUILayout.PropertyField(onCustomButtonPressed);
        EditorGUILayout.PropertyField (onModify);

        so.ApplyModifiedProperties();*//*
        DrawDefaultInspector();
        Drink drink = (Drink)target;

        *//*
        EditorGUILayout.BeginHorizontal();
        
        GUILayout.Label("UnityEvent parameters");
        flavourEnum = (Flavour)EditorGUILayout.EnumPopup(flavourEnum);
        flavourValue = EditorGUILayout.FloatField(flavourValue);
        
        EditorGUILayout.EndHorizontal();*//*

        if (GUILayout.Button("Muda Valor (Custom)"))
        {
            //drink.OnCustomButtonPressed?.Invoke(flavourEnum, flavourValue);
            drink.OnCustomButtonPressed?.Invoke(Flavour.sour, 1.0f);
        }

        if (GUILayout.Button("Muda Valor"))
        {
            drink.OnModify?.Invoke(1f,1f,1f,1f);
        }
    }
}*/
/*
[CustomPropertyDrawer(typeof(FlavourArgumentEvent))]
public class FlavourArgumentEventDrawer : UnityEventDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Draw the default UnityEvent GUI
        base.OnGUI(position, property, label);

        // Fetch the arguments property
        SerializedProperty argument0 = property.FindPropertyRelative("m_Arguments.m_Objects.Array.data[0]");
        SerializedProperty argument1 = property.FindPropertyRelative("m_Arguments.m_Floats.Array.data[0]");

        Debug.Log(argument0);

        // Check if they exist
        if (argument0 != null && argument1 != null)
        {
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            // Draw the Enum Popup for the Flavour argument
            EditorGUI.PropertyField(position, argument0, new GUIContent("Flavour Argument"));

            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            // Draw the Float field for the float argument
            EditorGUI.PropertyField(position, argument1, new GUIContent("Float Argument"));
        }
    }
}

[CustomPropertyDrawer(typeof(FloatArgumentEvent))]
public class FloatArgumentEventDrawer : UnityEventDrawer 
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Draw the default UnityEvent GUI
        base.OnGUI(position, property, label);

        // Fetch the arguments property
        SerializedProperty argument0 = property.FindPropertyRelative("m_Arguments.m_Floats.Array.data[0]");
        SerializedProperty argument1 = property.FindPropertyRelative("m_Arguments.m_Floats.Array.data[1]");
        SerializedProperty argument2 = property.FindPropertyRelative("m_Arguments.m_Floats.Array.data[2]");
        SerializedProperty argument3 = property.FindPropertyRelative("m_Arguments.m_Floats.Array.data[3]");

        // Check if they exist
        if (argument0 != null && argument1 != null && argument2 != null && argument3 != null)
        {
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            // Draw the Float fields for each argument
            EditorGUI.PropertyField(position, argument0, new GUIContent("Sourness Argument"));

            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.PropertyField(position, argument1, new GUIContent("Bitterness Argument"));

            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.PropertyField(position, argument2, new GUIContent("Sweetness Argument"));

            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            EditorGUI.PropertyField(position, argument3, new GUIContent("Saltiness Argument"));
        }
    }
}

*/