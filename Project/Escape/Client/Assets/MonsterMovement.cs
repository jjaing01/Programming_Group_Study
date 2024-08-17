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
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoveNext = (false == navMeshAgent.pathPending)
            && (navMeshAgent.remainingDistance <= RemainingDistanceForNext);

        if (isMoveNext)
        {
            MoveNextPatrolPoint();
        }
    }

    void Init()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        patrolPoints = new List<GameObject>();
        GameObject patrolPoint = null;

        patrolPoint = GameObject.Find("Patrol Point LT");
        patrolPoints.Add(patrolPoint);
        patrolPoint = GameObject.Find("Patrol Point LB");
        patrolPoints.Add(patrolPoint);
        patrolPoint = GameObject.Find("Patrol Point RB");
        patrolPoints.Add(patrolPoint);
        patrolPoint = GameObject.Find("Patrol Point RT");
        patrolPoints.Add(patrolPoint);

        curPatrolPoint = 1;
        UpdatePatrolPoint(curPatrolPoint);
    }

    void UpdatePatrolPoint(int index)
    {
        if (patrolPoints is null || patrolPoints.Count == 0)
        {
            return;
        }

        if (patrolPoints[index])
        {
            navMeshAgent.destination = patrolPoints[index].transform.position;
        }
        else
        {
            navMeshAgent.destination = new Vector3();
        }
    }

    void MoveNextPatrolPoint()
    {
        ++curPatrolPoint;
        if (curPatrolPoint >= patrolPoints.Count)
        {
            curPatrolPoint = 0;
        }

        UpdatePatrolPoint(curPatrolPoint);
    }

    private NavMeshAgent navMeshAgent;
    private List<GameObject> patrolPoints;
    private int curPatrolPoint;
    private const float RemainingDistanceForNext = 1.5f;
}
