using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class flower : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    Transform PlayerTrans;

    public SkinnedMeshRenderer _skinnedMeshRenderer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _skinnedMeshRenderer.SetBlendShapeWeight(0, 100);
        }
    }
}
