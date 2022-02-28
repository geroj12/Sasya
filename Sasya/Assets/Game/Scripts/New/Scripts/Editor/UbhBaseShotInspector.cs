using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects, CustomEditor(typeof(BaseShot), true)]
public class UbhBaseShotInspector : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawProperties();
        serializedObject.ApplyModifiedProperties();
    }

    private void DrawProperties()
    {
        var obj = target as BaseShot;

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Start Shot"))
        {
            if (Application.isPlaying && obj.gameObject.activeInHierarchy)
            {
                obj.Shot();
            }
        }
        EditorGUILayout.EndHorizontal();

        if (obj.m_bulletPrefab == null)
        {
            Color guiColor = GUI.color;
            GUI.color = Color.yellow;

            EditorGUILayout.LabelField("*****WARNING*****");
            EditorGUILayout.LabelField("BulletPrefab has not been set!");

            GUI.color = guiColor;
        }

        EditorGUILayout.Space();

        DrawDefaultInspector();
    }
}