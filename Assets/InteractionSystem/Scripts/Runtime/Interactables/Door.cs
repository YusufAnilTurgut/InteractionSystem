// 2. Unity namespaces
using UnityEngine;
using UnityEngine.Events;
using Project.Runtime.Core;
using System.Collections;

namespace Project.Runtime.Interactables
{
    public class Door : InteractableBase
    {
        #region Fields

        [Header("Instant Interaction")]
        [SerializeField] private UnityEvent m_OnInteract;

        [SerializeField] private bool m_DisableAfterInteract = false;

        [SerializeField] private Transform m_Hinge;
        [SerializeField] private float m_OpenAngle = 90f;
        [SerializeField] private float m_RotateSpeed = 180f;

        private bool m_IsOpen;
        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;


        private bool m_isOpen = false;
        #endregion

        #region Methods
        private void Awake()
        {

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

        protected override void PerformInteract()
        {
            if (m_OnInteract == null)
            {
                Debug.LogWarning($"{name}: OnInteract event is null.");
                return;
            }
            Debug.Log($"{name}: Instant interaction performed.");
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
