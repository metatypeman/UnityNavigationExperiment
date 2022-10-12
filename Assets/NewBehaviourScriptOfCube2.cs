using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class NewBehaviourScriptOfCube2 : MonoBehaviour
{
    public string Id;

    void OnValidate()
    {
        Debug.Log($"NewBehaviourScriptOfCube2 OnValidate PrefabStageUtility.GetCurrentPrefabStage() == null = {PrefabStageUtility.GetCurrentPrefabStage() == null}");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
