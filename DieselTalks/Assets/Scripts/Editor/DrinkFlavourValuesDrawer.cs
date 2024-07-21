using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DrinkProperties))]
public class DrinkFlavourValuesDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty flavours = property.FindPropertyRelative("Flavours");

        if (flavours == null || flavours.arraySize < 4)
        {
            EditorGUI.LabelField(position, label.text, "Flavours property not found or not initialized properly.");
            return;
        }

        EditorGUI.LabelField(new Rect(position.x, position.y, position.width, 16), label.text);

        for (int i = 0; i < flavours.arraySize; i++)
        {
            EditorGUILayout.PropertyField
            (
                flavours.GetArrayElementAtIndex(i), 
                new GUIContent(((Flavour)i).ToString() + " Value")
            );
        }
    }
}