using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace prisonescape
{
    public class GuardMovement : MonoBehaviour
    {
        NavMeshAgent agent;

        public Transform[] patrolPositions;
        private int currentPositionIndex = 0;


        private Vector3 targetPosition;

        private bool isMoving = false;

        private void Awake()
        {
            transform.position = patrolPositions[0].position;
            PatrolMovement();
        }

        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isMoving)
            {
                // Move the character
                agent.SetDestination(targetPosition);

                // Check if the character has reached the target position
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isMoving = false;
                    PatrolMovement(); // Set a new random target position
                }
            }
        }

        void PatrolMovement()
        {
            if (patrolPositions.Length - 1 > currentPositionIndex)
            {
                currentPositionIndex++;
            }
            else
            {
                currentPositionIndex = 0;
            }

            // Set the target position with the same Y and Z coordinates
            targetPosition = patrolPositions[currentPositionIndex].position;

            // Character starts moving towards the new target
            isMoving = true;
        }
    }
}

