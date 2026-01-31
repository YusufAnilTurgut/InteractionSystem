namespace Project.Runtime.Core
{
    public abstract class SwitchInteractableBase : InteractableBase
    {
        protected bool m_isToggle = false;

        #region Methods

        protected override void PerformInteract()
        {
            OnSwitchInteract();
        }

        protected abstract void OnSwitchInteract();

        #endregion
    }
}
