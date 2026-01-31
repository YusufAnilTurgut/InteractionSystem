namespace Project.Runtime.Core
{
    public interface IInteractable
    {
        bool CanInteract { get; }
        string PromptText { get; }

        void Interact();
    }
}
