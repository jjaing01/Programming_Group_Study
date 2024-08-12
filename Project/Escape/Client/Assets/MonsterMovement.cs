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

        goalPoint = GameObject.Find("Patrol Point RB");
        if (goalPoint)
        {
            nmAgent.destination = goalPoint.transform.position;
        }
        else
        {
            nmAgent.destination = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nmAgent.SetDestination(nmAgent.destination);
    }

    NavMeshAgent nmAgent;
    private GameObject goalPoint;
}
