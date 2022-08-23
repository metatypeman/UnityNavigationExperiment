using Assets.MyNavigation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.ParticleSystem;

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

                var myNavigationObjs = FindObjectsOfType<MyAbstractArea>();

                Debug.Log($"myNavigationObjs.Length = {myNavigationObjs.Length}");

                foreach (var element in myNavigationObjs)
                {
                    Debug.Log($"element.name = {element.name}");
                }

                var firstElem = myNavigationObjs.First();

                var lastElem = myNavigationObjs.Last();

                var path = new NavMeshPath();

                var pathRez = NavMesh.CalculatePath(firstElem.transform.position, lastElem.transform.position, NavMesh.AllAreas, path);

                Debug.Log($"pathRez = {pathRez}");

                for (int i = 0; i < path.corners.Length - 1; i++)
                {
                    //Gizmos.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
                    Debug.Log($"path.corners[{i}] = {path.corners[i]}");
                }


                //var triangulation = NavMesh.CalculateTriangulation();

                //foreach(var verticle in triangulation.vertices)
                //{
                //    Debug.Log($"verticle = {verticle}");
                //}

                Debug.Log("End!");
            }
        }
    }
}
