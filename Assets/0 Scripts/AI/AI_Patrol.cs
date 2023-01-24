using System.Collections.Generic;
using CollectCubes.Managers;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace CollectCubes.AI
{
    public class AI_Patrol : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private List<Transform> _leftWaypoints;
        private List<Transform> _rightWaypoints;

        private int _destPointIndex;
        private int _randomizingFactor; // Randomizing factor which is used for randomize the path for AI.

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            _leftWaypoints = WaypointHandler.Instance.leftWaypoints;
            _rightWaypoints = WaypointHandler.Instance.rightWaypoints;
            
            // ===== Event Assignments =====
            EventManager.onUpdate += PatrolAroundWaypoints;
            EventManager.onTimerStops += StopPatrolling;
            EventManager.onGameDifficultySelected += SetDifficultyValues;
            EventManager.onAI_Respawn += SetDifficultyValues;
            EventManager.onAI_Explodes += OnExplosion;
        }

        /// <summary>
        /// Sets the AI behaviour based on game difficulty.
        /// </summary>
        private void SetDifficultyValues()
        {
            switch (GameManager.GameDifficulty)
            {
                case GameDifficulty.Easy:
                    _agent.speed = 1.4f;
                    _agent.obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
                    break;
                
                case GameDifficulty.Medium:
                    _agent.speed = 1.8f;
                    _agent.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
                    break;
                
                case GameDifficulty.Hard:
                    _agent.speed = 2.2f;
                    _agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
                    break;
            }
        }

        /// <summary>
        /// Makes AI patrol between the given waypoints.
        /// </summary>
        private void PatrolAroundWaypoints()
        {
            if (_leftWaypoints.Count == 0) return;
            if (_agent.pathPending || !(_agent.remainingDistance < .1f)) return;
            
            if(_destPointIndex == 0)// When AI completed a tour randomize the path.
                _randomizingFactor = Random.Range(0, 2);

            switch (_randomizingFactor)
            {
                case 0:
                    _agent.SetDestination(_leftWaypoints[_destPointIndex++].position);
                    break;
                case 1:
                    _agent.SetDestination(_rightWaypoints[_destPointIndex++].position);
                    break;
            }

            _destPointIndex %= _leftWaypoints.Count;
        }
        
        /// <summary>
        /// Stops the patrolling when the time runs out.
        /// </summary>
        private void StopPatrolling()
        {
            EventManager.onUpdate -= PatrolAroundWaypoints;
            _agent.autoBraking = true;
        }

        private void OnExplosion()
        {
            _agent.speed = 0;
            _destPointIndex = 0;
        }
    }
}

