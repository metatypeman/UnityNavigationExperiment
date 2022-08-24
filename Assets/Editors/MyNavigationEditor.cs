using Assets.MyNavigation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
            var wnd = GetWindow<MyNavigationEditor>(false, "My Navigation Editor");
        }

        void OnGUI()
        {
            if (GUILayout.Button("Popup Options", GUILayout.Width(200)))
            {
                BakeMyNavigation();
            }
        }

        private void BakeMyNavigation()
        {
            Debug.Log("Begin!");

            var logger = NLogFactory.GetLogger();

            logger.Info("Begin!");

            var allMyNavigationObjList = FindObjectsOfType<MyAbstractArea>();

            logger.Info($"allMyNavigationObjList.Length = {allMyNavigationObjList.Length}");

            var allMySignificantNavigationObjList = allMyNavigationObjList.Where(p => p.IsMyWay || p.IsMyArea || p.IsMyLinkingWayPoint).ToList();

            logger.Info($"allMySignificantNavigationObjList.Count = {allMySignificantNavigationObjList.Count}");

            foreach (var element in allMySignificantNavigationObjList)
            {
                logger.Info($"element.name = {element.name}");

                var anotherMySignificantNavigationObjList = allMySignificantNavigationObjList.Where(p => p != element).ToList();

                logger.Info($"anotherMySignificantNavigationObjList.Count = {anotherMySignificantNavigationObjList.Count}");

                foreach(var anotherElement in anotherMySignificantNavigationObjList)
                {
                    logger.Info($"anotherElement.name = {anotherElement.name}");

                    var path = new NavMeshPath();

                    logger.Info($"element.CentralPoint = {element.CentralPoint}");
                    logger.Info($"anotherElement.CentralPoint = {anotherElement.CentralPoint}");

                    var pathRez = NavMesh.CalculatePath(element.CentralPoint, anotherElement.CentralPoint, NavMesh.AllAreas, path);

                    logger.Info($"pathRez = {pathRez}");

                    foreach(var corner in path.corners)
                    {
                        logger.Info($"corner = {corner}");
                    }
                }
            }

            //var firstElem = myNavigationObjs.First();

            //var lastElem = myNavigationObjs.Last();

            //var path = new NavMeshPath();

            //var pathRez = NavMesh.CalculatePath(firstElem.transform.position, lastElem.transform.position, NavMesh.AllAreas, path);

            //Debug.Log($"pathRez = {pathRez}");

            //for (int i = 0; i < path.corners.Length - 1; i++)
            //{
            //    //Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            //    Debug.Log($"path.corners[{i}] = {path.corners[i]}");
            //}

            logger.Info("End!");
            Debug.Log("End!");
        }
    }
}
