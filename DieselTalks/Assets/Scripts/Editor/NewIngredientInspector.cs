using System.Collections;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.Bartending;
using UnityEditor.TerrainTools;

[CustomEditor(typeof(NewIngredient))]
public class NewIngredientInspector : Editor
{
    SerializedProperty
        textureProperty,
        tasteProperty;
    private void OnEnable()
    {
        textureProperty = serializedObject.FindProperty("ingredientTexture");
        tasteProperty = serializedObject.FindProperty("ingredientTaste");

    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();

        NewIngredient newIngredient = (NewIngredient)target;
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
