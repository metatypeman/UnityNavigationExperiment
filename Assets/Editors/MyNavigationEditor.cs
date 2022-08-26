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

            var allMySignificantNavigationObjList = allMyNavigationObjList.Where(p => p.IsMyWay || p.IsMyArea || p.IsMyLinkingWayPoint).ToArray();

            logger.Info($"allMySignificantNavigationObjList.Length = {allMySignificantNavigationObjList.Length}");

            foreach (var element in allMySignificantNavigationObjList)
            {
                logger.Info($"element.name = {element.name}");

                var anotherMySignificantNavigationObjList = allMySignificantNavigationObjList.Where(p => p != element).ToArray();

                logger.Info($"anotherMySignificantNavigationObjList.Length = {anotherMySignificantNavigationObjList.Length}");

                foreach(var anotherElement in anotherMySignificantNavigationObjList)
                {
                    logger.Info($"anotherElement.name = {anotherElement.name}");

                    var path = new NavMeshPath();

                    logger.Info($"element.CentralPoint = {element.CentralPoint}");
                    logger.Info($"anotherElement.CentralPoint = {anotherElement.CentralPoint}");

                    var pathRez = NavMesh.CalculatePath(element.CentralPoint, anotherElement.CentralPoint, NavMesh.AllAreas, path);

                    logger.Info($"pathRez = {pathRez}");

                    if(!pathRez)
                    {
                        continue;
                    }

                    var intermediateMySignificantNavigationObjList = anotherMySignificantNavigationObjList.Where(p => p != element && p != anotherElement).ToArray();

                    logger.Info($"intermediateMySignificantNavigationObjList.Length = {intermediateMySignificantNavigationObjList.Length}");

                    foreach (var corner in path.corners.Select(p => new Vector3(p.x, p.y, p.z)))
                    {
                        logger.Info($"corner = {corner}");

                        var ray = new Ray(corner, Vector3.down);
                        
                        var hits = Physics.RaycastAll(ray);

                        logger.Info($"hits.Length = {hits.Length}");

                        foreach(var hit in hits)
                        {
                            logger.Info($"hit.point = {hit.point}");
                            logger.Info($"hit.distance = {hit.distance}");
                            logger.Info($"hit.transform.gameObject.name = {hit.transform.gameObject.name}");
                            logger.Info($"hit.transform.gameObject.GetInstanceID() = {hit.transform.gameObject.GetInstanceID()}");
                        }

                        //logger.Info($"element.ContainsPoint(corner) = {element.ContainsPoint(corner)}");
                        //logger.Info($"anotherElement.ContainsPoint(corner) = {anotherElement.ContainsPoint(corner)}");

                        //foreach (var intermediateElement in intermediateMySignificantNavigationObjList)
                        //{
                        //    logger.Info($"intermediateElement.name = {intermediateElement.name}");

                        //    logger.Info($"intermediateElement.ContainsPoint(corner) = {intermediateElement.ContainsPoint(corner)}");
                        //}
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
