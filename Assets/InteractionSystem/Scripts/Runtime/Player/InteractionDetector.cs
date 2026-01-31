// 1. System namespaces
using System;

// 2. Unity namespaces
using UnityEngine;
using UnityEngine.InputSystem;

// 4. Project namespaces
using Project.Runtime.Core;

namespace Project.Runtime.Player
{
    public sealed class InteractionDetector : MonoBehaviour
    {
        #region Events

        public event Action<IInteractable> OnTargetChanged;

        #endregion

        #region Fields

        [Header("Ray Origin")]
        [SerializeField] private Transform m_RayOrigin;

        [Header("Detection")]
        [SerializeField] private float m_Range;
        [SerializeField] private float m_SphereRadius;
        [SerializeField] private LayerMask m_InteractableMask = -1;

        [Header("Input (Configurable)")]
        [SerializeField] private InputActionReference m_InteractAction;

        private IInteractable m_CurrentTarget;
        private bool m_DebugDraw = true;
        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_RayOrigin == null)
            {
                Debug.LogError("RayOrigin is missing.");
                enabled = false;
                return;
            }

            if (m_InteractAction == null)
            {
                Debug.LogError("InteractAction is missing.");
                enabled = false;
                return;
            }
        }

        private void OnEnable()
        {
            m_InteractAction.action.Enable();
            m_InteractAction.action.performed += OnInteractPerformed;
        }

        private void Update()
        {
            UpdateTarget();
        }

        private void OnDisable()
        {
            m_InteractAction.action.performed -= OnInteractPerformed;
            m_InteractAction.action.Disable();
        }

        #endregion

        #region Methods

        private void UpdateTarget()
        {   

            IInteractable newTarget = FindBestTarget();
        
            if (ReferenceEquals(newTarget, m_CurrentTarget))
            {
                return;
            }

            m_CurrentTarget = newTarget;
            OnTargetChanged?.Invoke(m_CurrentTarget);
        }

        private IInteractable FindBestTarget()
        {
            Vector3 origin = m_RayOrigin.position;
            Vector3 direction = m_RayOrigin.forward;

            if (m_DebugDraw)
            {
                Debug.DrawRay(origin, direction * m_Range);
            }


            RaycastHit[] hits = Physics.SphereCastAll(
                origin,
                m_SphereRadius,
                direction,
                m_Range,
                m_InteractableMask,
                QueryTriggerInteraction.Collide);

            if (hits == null || hits.Length == 0)
            {
                return null;
            }

            float bestDistance = float.MaxValue;
            IInteractable best = null;

            for (int i = 0; i < hits.Length; i++)
            {
                Collider col = hits[i].collider;
                if (col == null)
                {
                    continue;
                }

                IInteractable interactable = col.GetComponentInParent<IInteractable>();
                if (interactable == null)
                {
                    continue;
                }

                float distance = hits[i].distance;
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    best = interactable;
                }
            }

            return best;
        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            Debug.Log("Interact Key performed");
            if (m_CurrentTarget == null)
            {   
                Debug.Log("No current target to interact with.");
                return;
            }

            if (!m_CurrentTarget.CanInteract)
            {
                Debug.Log("Current target cannot be interacted with.");
                return;
            }

            m_CurrentTarget.Interact();
        }

        #endregion
    }
}
