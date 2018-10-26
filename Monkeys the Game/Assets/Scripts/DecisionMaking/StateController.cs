using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using Complete;

public class StateController : MonoBehaviour
{

    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public State remainState;
    public List<Transform> wayPoints;


     public NavMeshAgent navMeshAgent;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;


    void Awake()
    {
        Debug.Log("Got here");
        wayPointList = wayPoints;
        navMeshAgent.enabled = true;
        navMeshAgent = GetComponent<NavMeshAgent> ();
        navMeshAgent.enabled = true;

    }

    public void SetupAI(bool aiActivationFromManager, List<Transform> wayPointsFromManager)
    {
        //Debug.Log("Got here?");
        //wayPointList = wayPointsFromManager;
        //aiActive = aiActivationFromManager;
        //if (aiActive)
        //{
        //    navMeshAgent.enabled = true;
        //}
        //else
        //{
        //    navMeshAgent.enabled = false;
        //}
    }

    void Update()
    {
        aiActive = true;
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}