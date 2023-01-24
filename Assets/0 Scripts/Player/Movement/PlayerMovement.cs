using System;
using System.Collections;
using System.Collections.Generic;
using CollectCubes.Managers;
using UnityEngine;

namespace CollectCubes.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Player Data")]
        [SerializeField] private DataManager gameData;

        [Header("Component References")] 
        [SerializeField] private Transform playerTransform; // Transform component of the player
        [SerializeField] private FloatingJoystick floatingJoystick;

        private void Start()
        {
            // ===== Event Assignments =====
            EventManager.onUpdate += Move;
            EventManager.onUpdate += Rotate;

            EventManager.onTimerStops += CancelInput; // Cancel input when the timer stops.
            EventManager.onPlayerExplodes += CancelInput;
            EventManager.onPlayerRespawn += GetInput;
        }

        /// <summary>
        /// Moves the character by given joystick input
        /// </summary>
        private void Move()
        {
            if (floatingJoystick.Vertical != 0 && floatingJoystick.Horizontal != 0)
                playerTransform.position+=(new Vector3(floatingJoystick.Horizontal, 0, floatingJoystick.Vertical) * (Time.deltaTime * gameData.characterSpeed));
        }

        /// <summary>
        /// Rotates the character towards touch delta.
        /// </summary>
        private void Rotate()
        {
            var direction = (Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal)
                .normalized;
            
            if (direction == Vector3.zero) return;

            var rotGoal = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation,rotGoal,100 * Time.deltaTime);
        }

        /// <summary>
        /// Cancels the input when the timer stops.
        /// </summary>
        private void CancelInput()
        {
            EventManager.onUpdate -= Move;
            EventManager.onUpdate -= Rotate;
            floatingJoystick.input = Vector2.zero;
        }
        
        private void GetInput()
        {
            EventManager.onUpdate += Move;
            EventManager.onUpdate += Rotate;
        }
        
    }

}
