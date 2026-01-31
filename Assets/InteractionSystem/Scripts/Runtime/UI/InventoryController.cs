// 2. Unity namespaces
using UnityEngine;

// 4. Project namespaces
using Project.Runtime.Player;

namespace Project.Runtime.UI
{
    public sealed class InventoryController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private PlayerInventory m_PlayerInventory;
        [SerializeField] private GameObject m_KeyImage;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            if (m_PlayerInventory == null)
            {
                Debug.LogError("PlayerInventory reference is missing.");
                enabled = false;
                return;
            }

            if (m_KeyImage == null)
            {
                Debug.LogError("KeyImage reference is missing.");
                enabled = false;
                return;
            }

            UpdateUI();
        }

        private void Update()
        {
            UpdateUI();
        }

        #endregion

        #region Methods

        private void UpdateUI()
        {
            bool hasKey = m_PlayerInventory.HasKey;
            m_KeyImage.SetActive(hasKey);
        }

        #endregion
    }
}
