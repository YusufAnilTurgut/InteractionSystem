using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Project.Runtime.Core;

namespace Project.Runtime.Interactables
{
    public sealed class Chest : HoldInteractableBase
    {
        #region Fields

        [Header("Lid")]
        [SerializeField] private Transform m_Lid;
        [SerializeField] private float m_OpenAngle = 75f;
        [SerializeField] private float m_OpenDuration = 1.5f;

        [Header("Events")]
        [SerializeField] private UnityEvent m_OnOpened;

        private bool m_IsOpened;
        private Coroutine m_OpenRoutine;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_Lid == null)
            {
                Debug.LogError("Chest lid is missing.");
                enabled = false;
            }
        }

        #endregion

        #region Methods

        protected override void OnHoldCompleted()
        {
            if (m_IsOpened)
            {
                return;
            }

            m_IsOpened = true;
            SetCanInteract(false);

            if (m_OpenRoutine != null)
            {
                StopCoroutine(m_OpenRoutine);
            }

            m_OpenRoutine = StartCoroutine(OpenLidRoutine());
            m_OnOpened?.Invoke();
        }

        private IEnumerator OpenLidRoutine()
        {
            Quaternion startRotation = m_Lid.localRotation;
            Quaternion targetRotation = Quaternion.Euler(-m_OpenAngle, 0f, 0f);

            float elapsed = 0f;

            while (elapsed < m_OpenDuration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / m_OpenDuration);
                m_Lid.localRotation = Quaternion.Slerp(startRotation, targetRotation, t);
                yield return null;
            }

            m_Lid.localRotation = targetRotation;
        }

        #endregion
    }
}
