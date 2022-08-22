using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Editors
{
    public class MyNavigationEditor : EditorWindow
    {
        [MenuItem("Tools/My Navigation Editor")]
        public static void ShowMyEditor()
        {
            // This method is called when the user selects the menu item in the Editor
            var wnd = GetWindow<MyNavigationEditor>(false, "My Custom Editor");
        }

        void OnGUI()
        {
            if (GUILayout.Button("Popup Options", GUILayout.Width(200)))
            {
                Debug.Log("Hi!");

                var triangulation = NavMesh.CalculateTriangulation();

                foreach(var verticle in triangulation.vertices)
                {
                    Debug.Log($"verticle = {verticle}");
                }

                Debug.Log("End!");
            }
        }
    }
}
