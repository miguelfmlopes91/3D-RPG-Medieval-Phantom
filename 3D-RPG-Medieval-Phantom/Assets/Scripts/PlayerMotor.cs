using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent  = GetComponent<NavMeshAgent>();
    }
    private void Update() {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    public void MoveToPoint(Vector3 point){
        agent.SetDestination(point);
    }

    public void FollowTarget(InteractbleObject newTarget){
        agent.stoppingDistance = newTarget.radius * .8f;
        target = newTarget.transform;
    }

    public void StopFollowingTarget(){
        agent.stoppingDistance = 0f;
        target = null;
    }
}
