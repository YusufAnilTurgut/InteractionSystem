namespace Project.Runtime.Core
{
    public interface IInteractable
    {
        bool CanInteract { get; }
        string PromptText { get; }

                
        bool IsHoldInteract { get; }
        float HoldDuration { get; }
        
        void Interact();
    }
}
