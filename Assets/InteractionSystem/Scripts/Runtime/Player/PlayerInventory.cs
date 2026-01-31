using UnityEngine;
using Project.Runtime.Items;

namespace Project.Runtime.Player
{
    public sealed class PlayerInventory : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SO_Key m_CurrentKey;

        #endregion

        #region Properties

        public bool HasKey => m_CurrentKey != null;

        #endregion

        #region Methods

        public void SetKey(SO_Key key)
        {
            m_CurrentKey = key;
        }

        public void ClearKey()
        {
            m_CurrentKey = null;
        }

        #endregion
    }
}
