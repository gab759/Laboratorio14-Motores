using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using TMPro;

public class MovementNpc : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints; 
    [SerializeField] private float waitTime = 2f; 
    [SerializeField] private Image textoFondo; 
    [SerializeField] private TextMeshProUGUI text; 
    [SerializeField] private float interactionTime = 2f; 
    [SerializeField] private PlayerController player; 

    private int currentPatrolIndex = 0;
    private bool interactionPlayer = false;
    private bool puedoPatrullar = true;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        textoFondo.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (puedoPatrullar && !interactionPlayer)
        {
            MoveToNextPatrolPoint();
        }

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            puedoPatrullar = false;
            navMeshAgent.isStopped = true;
            StartCoroutine(Patrol());
        }
    }

    private void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;   
        }
    }

    private IEnumerator Patrol()
    {
        yield return new WaitForSeconds(waitTime);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        puedoPatrullar = true;
        navMeshAgent.isStopped = false;

    }

    private IEnumerator NoCollisionPlayer()
    {
        yield return new WaitForSeconds(interactionTime);
        interactionPlayer = false;
        textoFondo.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.interactiveNPC)
            {
                interactionPlayer = true;
                StartCoroutine(NoCollisionPlayer());
                textoFondo.gameObject.SetActive(true);
                text.gameObject.SetActive(true);
            }
        }
    }
}

