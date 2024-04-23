using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private List<Transform> patrolPointsPos;
    [SerializeField] private TMP_Text healthBar;
    [SerializeField] private GameController gm;

    private float detectionRange = 6f;
    private GameObject player;
    private Enemy enemy;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //patrolPoints = GameObject.FindGameObjectsWithTag("Patrol Point");
        enemy = gameObject.AddComponent<Enemy>();

        //foreach (GameObject point in patrolPoints)
        //{
        //    patrolPointsPos.Add(point.transform);

        //}

    }

    private void Update()
    {
        Transform playerPos = player.transform;
        if (Vector3.Distance(transform.position, playerPos.position) < detectionRange)
        {
            agent.SetDestination(playerPos.position);
        }
        else if (agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            Invoke("Patrol", 2);
        }
        healthBar.transform.LookAt(player.transform);

    }

    private void Patrol()
    {
        int randPatrolPoint = Random.Range(0, patrolPointsPos.Count);
        agent.destination = patrolPointsPos[randPatrolPoint].position;
    }

    public void UpdateHealth()
    {
        healthBar.text = "Health: " + enemy.Health;

        if (enemy.Health <= 0)
        {
            gm.enemyCount--;
            Destroy(gameObject);
            gm.GamestateUpdate();
        }
    }

}
