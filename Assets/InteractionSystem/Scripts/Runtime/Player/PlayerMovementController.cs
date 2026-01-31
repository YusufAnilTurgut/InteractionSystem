// 1. System namespaces
using System;

// 2. Unity namespaces
using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Runtime.Player
{
    public sealed class PlayerMovementController : MonoBehaviour
    {
        #region Fields

        [Header("Movement")]
        [SerializeField] private float m_MoveSpeed;

        [Header("Look")]
        [SerializeField] private Transform m_CameraPivot;
        [SerializeField] private float m_LookSensitivity;
        [SerializeField] private float m_MaxPitch;

        [Header("References")]
        private Rigidbody m_Rigidbody;
        private PlayerInput m_PlayerInput;

        private InputAction m_MoveAction;
        private InputAction m_LookAction;

        private Vector2 m_MoveInput;
        private float m_Pitch;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            m_PlayerInput = GetComponent<PlayerInput>();
            m_Rigidbody = GetComponent<Rigidbody>();
            m_CameraPivot = transform.Find("CameraPivot");


            if (m_PlayerInput == null)
            {
                Debug.LogError("PlayerInput is missing.");
                enabled = false;
                return;
            }

            if (m_Rigidbody == null)
            {
                Debug.LogError("Rigidbody is missing.");
                enabled = false;
                return;
            }
            
            if (m_CameraPivot == null)
            {
                Debug.LogError("CameraPivot is missing1.");
                enabled = false;
                return;
            }

            m_MoveAction = m_PlayerInput.actions["Move"];
            m_LookAction = m_PlayerInput.actions["Look"];

            if (m_MoveAction == null || m_LookAction == null)
            {
                Debug.LogError("Input Actions not found. Check action names: Move, Look.");
                enabled = false;
            }
        }

        private void OnEnable()
        {
            m_MoveAction?.Enable();
            m_LookAction?.Enable();
        }

        private void Update()
        {
            m_MoveInput = m_MoveAction.ReadValue<Vector2>();
            HandleLook();
        }

        private void FixedUpdate()
        {
            HandleMove();
        }

        private void OnDisable()
        {
            m_MoveAction?.Disable();
            m_LookAction?.Disable();
        }

        #endregion

        #region Methods

        private void HandleMove()
        {
            Vector3 localMove = new Vector3(m_MoveInput.x, 0f, m_MoveInput.y); // W => +Z
            Vector3 worldMove = transform.TransformDirection(localMove) * m_MoveSpeed;

            Vector3 velocity = m_Rigidbody.linearVelocity;
            Vector3 targetVelocity = new Vector3(worldMove.x, velocity.y, worldMove.z);

            m_Rigidbody.linearVelocity = targetVelocity;
        }

        private void HandleLook()
        {
            Vector2 look = m_LookAction.ReadValue<Vector2>();
            float yaw = look.x * m_LookSensitivity;
            float pitchDelta = look.y * m_LookSensitivity;

            transform.Rotate(0f, yaw, 0f, Space.Self);

            m_Pitch = Mathf.Clamp(m_Pitch - pitchDelta, -m_MaxPitch, m_MaxPitch);
            m_CameraPivot.localRotation = Quaternion.Euler(m_Pitch, 0f, 0f);
        }

        #endregion
    }
}
