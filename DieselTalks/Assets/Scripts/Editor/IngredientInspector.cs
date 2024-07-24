using System.Collections;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.Bartending;
using UnityEditor.TerrainTools;
using System.Reflection.Emit;

[CustomEditor(typeof(Ingredient)), CanEditMultipleObjects]
public class IngredientInspector : Editor
{
    SerializedProperty
        textureProperty,
        tasteProperty,
        canvasProperty,
        holdTimeProperty;

    GUIContent
        canvasLabel,
        holdTimeLabel;

    private void OnEnable()
    {
        textureProperty = serializedObject.FindProperty("ingredientTexture");
        tasteProperty = serializedObject.FindProperty("ingredientTaste");
        canvasProperty = serializedObject.FindProperty("canvas");
        holdTimeProperty = serializedObject.FindProperty("holdTime");

        canvasLabel = new("Canvas");
        holdTimeLabel = new("Hold Time", "Tempo segurando até mover blabla");
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();

        EditorGUILayout.PropertyField(canvasProperty, canvasLabel);
        EditorGUILayout.PropertyField(holdTimeProperty, holdTimeLabel);

        Ingredient newIngredient = (Ingredient)target;
        newIngredient.isBase = EditorGUILayout.Toggle(newIngredient.isBase ? "Ingrediente Base" : "Ingrediente Complementar", newIngredient.isBase);

        if (newIngredient.isBase)
        {
            EditorGUILayout.PropertyField(textureProperty, true);
        }
        else EditorGUILayout.PropertyField(tasteProperty, true);

        serializedObject.ApplyModifiedProperties();

        if(GUILayout.Button("Aplica na bebida"))
        {
            newIngredient.AddIngredient();
        }
    }
}
