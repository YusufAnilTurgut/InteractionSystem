using UnityEngine;
using Project.Runtime.Core;
using Project.Runtime.Items;
using Project.Runtime.Player;

namespace Project.Runtime.Interactables
{
    public sealed class KeyPickup : InteractableBase
    {
        #region Fields

        [SerializeField] private SO_Key m_Key;
        [SerializeField] private PlayerInventory m_PlayerInventory;

        #endregion

        #region Methods

        protected override void PerformInteract()
        {
            if (m_PlayerInventory == null || m_Key == null)
            {
                return;
            }

            m_PlayerInventory.SetKey(m_Key);
            Destroy(gameObject);
        }

        #endregion
    }
}
