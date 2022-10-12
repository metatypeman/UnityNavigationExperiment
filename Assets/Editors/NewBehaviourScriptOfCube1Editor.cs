using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Assets.Editors
{
    [CustomEditor(typeof(NewBehaviourScriptOfCube1))]
    [CanEditMultipleObjects]
    public class NewBehaviourScriptOfCube1Editor : Editor
    {
        private NewBehaviourScriptOfCube1 _target;

        private void OnEnable()
        {
#if DEBUG
            Debug.Log($"NewBehaviourScriptOfCube1Editor OnEnable");
#endif

            _target = (NewBehaviourScriptOfCube1)target;
        }

        public override void OnInspectorGUI()
        {
#if DEBUG
            //Debug.Log($"NewBehaviourScriptOfCube1Editor OnInspectorGUI");
#endif

#if DEBUG
            //Debug.Log($"NewBehaviourScriptOfCube1Editor OnInspectorGUI IsPartOfPrefabAsset(_target) = {PrefabUtility.IsPartOfPrefabAsset(_target)}; IsPartOfAnyPrefab(_target) = {PrefabUtility.IsPartOfAnyPrefab(_target)}; IsPartOfNonAssetPrefabInstance(_target) = {PrefabUtility.IsPartOfNonAssetPrefabInstance(_target)}");
            //Debug.Log($"NewBehaviourScriptOfCube1Editor OnInspectorGUI PrefabStageUtility.GetCurrentPrefabStage() == null = {PrefabStageUtility.GetCurrentPrefabStage() == null}");
#endif

            GUILayout.BeginVertical();

            _target.Id = EditorGUILayout.TextField("Id", _target.Id);

            GUILayout.EndVertical();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(_target);
            }
        }
    }
}
