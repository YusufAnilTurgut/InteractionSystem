// 2. Unity namespaces
using UnityEngine;
using UnityEngine.Events;
using Project.Runtime.Core;
using System.Collections;
using Project.Runtime.Player;

namespace Project.Runtime.Interactables
{
    public class Door : InstantInteractableBase
    {
        #region Fields

        [Header("Instant Interaction")]
        [SerializeField] private UnityEvent m_OnInteract;

        [SerializeField] private PlayerInventory m_PlayerInventory;

        [SerializeField] private bool m_DisableAfterInteract = false;

        [SerializeField] private Transform m_Hinge;
        [SerializeField] private float m_OpenAngle = 90f;
        [SerializeField] private float m_RotateSpeed = 180f;

        [SerializeField] private bool m_IsLockedDoor = false;

        private bool m_IsLocked = false;

        private bool m_IsOpen;
        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;


        #endregion

        #region Methods
        private void Awake()
        {
            if (m_PlayerInventory == null)
            {
                Debug.LogError("PlayerInventory reference is missing.");
                enabled = false;
                return;
            }

            m_Hinge = transform.parent;
            if (m_Hinge == null)
            {
                Debug.LogError("Hinge reference is missing.");
                enabled = false;
                return;
            }

            m_ClosedRotation = m_Hinge.localRotation;
            m_OpenRotation = Quaternion.Euler(0f, m_OpenAngle, 0f);
        }

        protected override void OnInstantInteract()
        {
            if (m_OnInteract == null)
            {
                Debug.LogWarning($"{name}: OnInteract event is null.");
                return;
            }
            Debug.Log($"{name}: Instant interaction performed.");

            if (m_IsLockedDoor == true && !m_PlayerInventory.HasKey) 
            {
                Debug.Log($"{name}: The door is locked. Cannot interact.");
                return;
            }
            if (m_IsLockedDoor == true && m_PlayerInventory.HasKey) 
            {
                Debug.Log($"{name}: The door is unlocked using the key.");
                m_IsLocked = false;
                m_PlayerInventory.ClearKey();
            }
            
            m_OnInteract.Invoke();

            if (m_DisableAfterInteract)
            {
                SetCanInteract(false);
            }
        }

        public void OpenDoor()
        {
            Debug.Log($"{name}: Opening door.");
            m_IsOpen = !m_IsOpen;
            StopAllCoroutines();
            StartCoroutine(RotateDoor());
        }

        private IEnumerator RotateDoor()
        {
            Quaternion start = m_Hinge.localRotation;
            Quaternion target = m_IsOpen ? m_OpenRotation : m_ClosedRotation;

            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * (m_RotateSpeed / 90f);
                m_Hinge.localRotation = Quaternion.Slerp(start, target, t);
                yield return null;
            }

            m_Hinge.localRotation = target;
        }

        #endregion
    }
    
}
