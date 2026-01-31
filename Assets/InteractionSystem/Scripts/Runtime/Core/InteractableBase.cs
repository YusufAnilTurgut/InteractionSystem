// 2. Unity namespaces
using UnityEngine;

namespace Project.Runtime.Core
{
    public abstract class InteractableBase : MonoBehaviour, IInteractable
    {
        #region Fields

        [SerializeField] private string m_PromptText = "Interact";
        [SerializeField] private bool m_CanInteract = true;

        #endregion

        #region Properties

        public bool CanInteract => m_CanInteract;
        public string PromptText => m_PromptText;

        #endregion

        #region Interface Implementations

        void IInteractable.Interact()
        {
            if (!m_CanInteract)
            {
                Debug.LogWarning($"{name}: Cannot interact right now.");
                return;
            }

            PerformInteract();
        }

        #endregion

        #region Methods

        protected abstract void PerformInteract();

        protected void SetCanInteract(bool value)
        {
            m_CanInteract = value;
        }

        #endregion
    }
}
