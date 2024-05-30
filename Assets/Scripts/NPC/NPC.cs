using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent agent;
    private float playerDistance;
    public float detectDistance;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        playerDistance = Vector3.Distance(transform.position, CharacterManager.Instance.Player.transform.position);
        TranckingPlayer();
    }
    private void TranckingPlayer()
    {
        if (playerDistance < detectDistance)
        {
            agent.isStopped = false;
            NavMeshPath path = new NavMeshPath();
            if (agent.CalculatePath(CharacterManager.Instance.Player.transform.position, path))
            {
                agent.SetDestination(CharacterManager.Instance.Player.transform.position);
            }
            else
            {
                agent.SetDestination(transform.position);
                agent.isStopped = true;
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            agent.isStopped = true;
        }
    }
}
