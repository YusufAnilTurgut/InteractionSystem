// 2. Unity namespaces
using UnityEngine;

namespace Project.Runtime.Core
{
    public abstract class HoldInteractableBase : InteractableBase
    {
        #region Fields

        [Header("Hold Settings")]
        [SerializeField] private float m_HoldDuration = 2f;

        

        #endregion

        #region Properties

        public sealed override bool IsHoldInteract => true;
        public sealed override float HoldDuration => m_HoldDuration;

        #endregion

        #region Methods

        protected sealed override void PerformInteract()
        {
            OnHoldCompleted();
        }

        protected abstract void OnHoldCompleted();

        #endregion
    }
}
