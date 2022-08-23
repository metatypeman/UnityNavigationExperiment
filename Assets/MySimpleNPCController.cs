using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MySimpleNPCController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _gameObject;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _gameObject = GameObject.Find("Plane1");

        _agent.SetDestination(_gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
