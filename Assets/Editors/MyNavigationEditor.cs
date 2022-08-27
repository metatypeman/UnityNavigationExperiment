using Assets.MyNavigation;
using NLog;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.ParticleSystem;
using static UnityEngine.UI.GridLayoutGroup;

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

        public int DistanceQuantification = 5;

        void OnGUI()
        {
            DistanceQuantification = int.Parse(EditorGUILayout.TextField("Distance Quantification", DistanceQuantification.ToString()));

            if (GUILayout.Button("Popup Options", GUILayout.Width(200)))
            {
                BakeMyNavigation();
            }
        }

        private static NLog.Logger _logger = NLogFactory.GetLogger();

        private void BakeMyNavigation()
        {
            Debug.Log("Begin!");

            _logger.Info("Begin!");

            var allMyNavigationObjList = FindObjectsOfType<MyAbstractArea>();

            _logger.Info($"allMyNavigationObjList.Length = {allMyNavigationObjList.Length}");

            var allMyNavigationObjDict = allMyNavigationObjList.ToDictionary(p => p.InstanceId, p => p);

            var allMySignificantNavigationObjList = allMyNavigationObjList.Where(p => p.IsMyWay || p.IsMyArea || p.IsMyLinkingWayPoint).ToArray();

            _logger.Info($"allMySignificantNavigationObjList.Length = {allMySignificantNavigationObjList.Length}");

            foreach (var element in allMySignificantNavigationObjList)
            {
                _logger.Info($"element.name = {element.name}");
                _logger.Info($"element.InstanceId = {element.InstanceId}");

                var anotherMySignificantNavigationObjList = allMySignificantNavigationObjList.Where(p => p != element).ToArray();

                _logger.Info($"anotherMySignificantNavigationObjList.Length = {anotherMySignificantNavigationObjList.Length}");

                foreach(var anotherElement in anotherMySignificantNavigationObjList)
                {
                    _logger.Info($"anotherElement.name = {anotherElement.name}");
                    _logger.Info($"anotherElement.InstanceId = {anotherElement.InstanceId}");

                    var path = new NavMeshPath();

                    _logger.Info($"element.CentralPoint = {element.CentralPoint}");
                    _logger.Info($"anotherElement.CentralPoint = {anotherElement.CentralPoint}");

                    var pathRez = NavMesh.CalculatePath(element.CentralPoint, anotherElement.CentralPoint, NavMesh.AllAreas, path);

                    _logger.Info($"pathRez = {pathRez}");

                    if(!pathRez)
                    {
                        continue;
                    }

                    var lastInstanceId = element.InstanceId;

                    var lastPoint = element.CentralPoint;

                    foreach (var corner in path.corners)
                    {
                        _logger.Info($"corner = {corner}");

                        var distance = Vector3.Distance(lastPoint, corner);

                        _logger.Info($"distance = {distance}");

                        var intermediatePointsList = DivideByMaxDistanceDelta(lastPoint, corner, DistanceQuantification);

                        _logger.Info($"intermediatePointsList.Count = {intermediatePointsList.Count}");

                        lastPoint = corner;

                        foreach(var point in intermediatePointsList)
                        {
                            _logger.Info($"point = {point}");

                            var foundElementsList = ContainsPoint(point, lastInstanceId, allMyNavigationObjDict);

                            _logger.Info($"foundElementsList.Count = {foundElementsList.Count}");

                            if (foundElementsList.Count > 0)
                            {
                                if (foundElementsList.Count == 1)
                                {
                                    var foundElement = foundElementsList.First();

                                    _logger.Info($"foundElement.name = {foundElement.name}");
                                    _logger.Info($"foundElement.InstanceId = {foundElement.InstanceId}");

                                    lastInstanceId = foundElement.InstanceId;
                                }
                                else
                                {
                                    _logger.Info("????????????????????????????????????????????????????????????????????????????????");

                                    foreach (var foundElement in foundElementsList)
                                    {
                                        _logger.Info($"foundElement.name = {foundElement.name}");
                                        _logger.Info($"foundElement.InstanceId = {foundElement.InstanceId}");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            _logger.Info("End!");
            Debug.Log("End!");
        }

        private List<Vector3> DivideByMaxDistanceDelta(Vector3 current, Vector3 target, float maxDistanceDelta)
        {
            var result = new List<Vector3>();

            while(true)
            {
                //_logger.Info($"current = {current}");
                //_logger.Info($"target = {target}");
                //_logger.Info($"maxDistanceDelta = {maxDistanceDelta}");

                var pos = Vector3.MoveTowards(current, target, maxDistanceDelta);

                //_logger.Info($"pos = {pos}");

                result.Add(pos);

                if(pos == target)
                {
                    break;
                }

                current = pos;
            }

            return result;
        }

        private List<MyAbstractArea> ContainsPoint(Vector3 point, int lastInstanceId, Dictionary<int, MyAbstractArea> allMyNavigationObjDict)
        {
            var result = new List<MyAbstractArea>();

            var ray = new Ray(point, Vector3.down);
            var hits = Physics.RaycastAll(ray);

            //_logger.Info($"hits.Length = {hits.Length}");
            //_logger.Info($"lastInstanceId = {lastInstanceId}");

            foreach (var hit in hits)
            {
                //_logger.Info($"hit.point = {hit.point}");
                //_logger.Info($"hit.distance = {hit.distance}");
                //_logger.Info($"hit.transform.gameObject.name = {hit.transform.gameObject.name}");

                var hitInstanceId = hit.transform.gameObject.GetInstanceID();

                //_logger.Info($"hitInstanceId = {hitInstanceId}");

                if (hitInstanceId == lastInstanceId)
                {
                    continue;
                }

                if (allMyNavigationObjDict.ContainsKey(hitInstanceId))
                {
                    var targetNavElement = allMyNavigationObjDict[hitInstanceId];

                    //_logger.Info($"targetNavElement.name = {targetNavElement.name}");
                    //_logger.Info($"targetNavElement.InstanceId = {targetNavElement.InstanceId}");

                    result.Add(targetNavElement);
                }
            }

            return result;
        }
    }
}
