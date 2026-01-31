// 2. Unity namespaces
using UnityEngine;
using UnityEngine.Events;
using Project.Runtime.Core;

namespace Project.Runtime.Interactables
{
    public class InstantInteractable : InteractableBase
    {
        #region Fields

        [Header("Instant Interaction")]
        [SerializeField] private UnityEvent m_OnInteract;

        [SerializeField] private bool m_DisableAfterInteract = false;

        #endregion

        #region Methods

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

        #endregion
    }
}
