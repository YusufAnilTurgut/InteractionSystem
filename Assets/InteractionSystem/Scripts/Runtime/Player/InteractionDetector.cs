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

        public event Action<float> OnHoldProgressChanged;
        


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

        private bool m_IsHolding;
        private float m_HoldElapsed;
        private Project.Runtime.Core.HoldInteractableBase m_CurrentHoldTarget;
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
            m_InteractAction.action.started += OnInteractStarted;
            m_InteractAction.action.performed += OnInteractPerformed;
            m_InteractAction.action.canceled += OnInteractCanceled;

        }

        private void Update()
        {
            UpdateTarget();
            UpdateHold();

        }

        private void OnDisable()
        {
            m_InteractAction.action.started -= OnInteractStarted;
            m_InteractAction.action.performed -= OnInteractPerformed;
            m_InteractAction.action.canceled -= OnInteractCanceled;
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
            m_IsHolding = false;
            m_HoldElapsed = 0f;
            OnHoldProgressChanged?.Invoke(0f);
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

        private void OnInteractStarted(InputAction.CallbackContext context)
        {
            Debug.Log("Interact Started");
            if (m_CurrentTarget == null)
            {
                return;
            }

            if (!m_CurrentTarget.IsHoldInteract)
            {
                return;
            }

            if (!m_CurrentTarget.CanInteract)
            {
                return;
            }

            m_IsHolding = true;
            m_HoldElapsed = 0f;
            OnHoldProgressChanged?.Invoke(0f);

        }

        private void OnInteractCanceled(InputAction.CallbackContext context)
        {
            Debug.Log("Interact Canceled");
            m_IsHolding = false;
            m_HoldElapsed = 0f;
            OnHoldProgressChanged?.Invoke(0f);

        }

        private void OnInteractPerformed(InputAction.CallbackContext context)
        {
            Debug.Log("Interact Performed");
            if (m_CurrentTarget == null)
            {
                return;
            }

            if (m_CurrentTarget.IsHoldInteract)
            {
                return;
            }

            if (!m_CurrentTarget.CanInteract)
            {
                return;
            }

            m_CurrentTarget.Interact();
        }

        private void UpdateHold()
        {
            if (!m_IsHolding)
            {
                return;
            }

            if (m_CurrentTarget == null)
            {
                m_IsHolding = false;
                return;
            }

            if (!m_CurrentTarget.IsHoldInteract)
            {
                m_IsHolding = false;
                m_HoldElapsed = 0f;
                return;
            }

            float duration = m_CurrentTarget.HoldDuration;
            if (duration <= 0f)
            {
                Debug.LogError("HoldDuration must be > 0.");
                m_IsHolding = false;
                return;
            }

            m_HoldElapsed += Time.deltaTime;

            if (m_HoldElapsed >= duration)
            {
                m_IsHolding = false;
                m_HoldElapsed = 0f;

                if (m_CurrentTarget.CanInteract)
                {
                    OnHoldProgressChanged?.Invoke(0f);
                    m_CurrentTarget.Interact();
                }
            }

            float progress = Mathf.Clamp01(m_HoldElapsed / duration);
            OnHoldProgressChanged?.Invoke(progress);

        }


        #endregion
    }
}
