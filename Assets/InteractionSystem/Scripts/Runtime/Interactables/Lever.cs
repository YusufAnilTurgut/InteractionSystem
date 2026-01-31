// 2. Unity namespaces
using UnityEngine;
using UnityEngine.Events;
using Project.Runtime.Core;
using System.Collections;

namespace Project.Runtime.Interactables
{
    public class Lever : SwitchInteractableBase
    {
        #region Fields

        [Header("Instant Interaction")]
        [SerializeField] private UnityEvent m_OnInteract;
    
        [SerializeField] private bool m_DisableAfterInteract = false;

        [SerializeField] private Transform m_Fulcrum;

        [SerializeField] private float m_OpenAngle = 50f;
        [SerializeField] private float m_RotateSpeed = 180f;

        private bool m_IsOpen;
        private Quaternion m_ClosedRotation;
        private Quaternion m_OpenRotation;


        #endregion

        #region Methods
        private void Awake()
        {

            m_Fulcrum = transform.parent;
            if (m_Fulcrum == null)
            {
                Debug.LogError("Fulcrum reference is missing.");
                enabled = false;
                return;
            }

            m_ClosedRotation = m_Fulcrum.localRotation;
            m_OpenRotation = Quaternion.Euler(0f, 0f, m_OpenAngle);
        }

        protected override void OnSwitchInteract()
        {
            if (m_OnInteract == null)
            {
                Debug.LogWarning($"{name}: OnInteract event is null.");
                return;
            }
            Debug.Log($"{name}: Switch interaction performed.");
            m_OnInteract.Invoke();

            if (m_DisableAfterInteract)
            {
                SetCanInteract(false);
            }
        }
    
        public void SwitchLever()
        {
            Debug.Log($"{name}: Switching lever.");
            m_isToggle = !m_isToggle;
            StopAllCoroutines();
            StartCoroutine(RotateLever());
        }

        private IEnumerator RotateLever()
        {
            Quaternion start = m_Fulcrum.localRotation;
            Quaternion target = m_isToggle ? m_OpenRotation : m_ClosedRotation;

            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * (m_RotateSpeed / 90f);
                m_Fulcrum.localRotation = Quaternion.Slerp(start, target, t);
                yield return null;
            }

            m_Fulcrum.localRotation = target;
        }

        #endregion
    }
    
}
