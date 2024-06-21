using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    private AIPath path;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform target;

    private void Start()
    {
        path = GetComponent<AIPath>();
    }

    private void Update()
    {
        path.maxSpeed = moveSpeed;
        path.destination = target.position;
    }
}
