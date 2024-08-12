using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class MonsterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
       // nmAgent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        nmAgent.SetDestination(new Vector3(9, 0, 0));
    }

    NavMeshAgent nmAgent;
    public Transform goal;
    public GameObject goalPoint;
}
