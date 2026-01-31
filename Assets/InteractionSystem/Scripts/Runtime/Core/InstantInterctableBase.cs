namespace Project.Runtime.Core
{
    public abstract class InstantInteractableBase : InteractableBase
    {
        #region Methods

        protected override void PerformInteract()
        {
            OnInstantInteract();
        }

        protected abstract void OnInstantInteract();

        #endregion
    }
}
