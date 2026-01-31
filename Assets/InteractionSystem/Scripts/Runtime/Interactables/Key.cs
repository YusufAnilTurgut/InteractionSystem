// 2. Unity namespaces
using UnityEngine;
using UnityEngine.Events;
using Project.Runtime.Core;
using System.Collections;

namespace Project.Runtime.Interactables
{
    public class Key : InstantInteractableBase
    {
        #region Fields

        [Header("Instant Interaction")]
        [SerializeField] private UnityEvent m_OnInteract;

        [SerializeField] private bool m_DisableAfterInteract = true;

        private bool m_IsUsed;
        #endregion

        #region Methods
        private void Awake()
        {

          
        }

        protected override void OnInstantInteract()
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
