public interface IInteracteble
{
    public abstract void BaseInteract();
    public abstract void EnterCursor(bool isVisible);
    public string Description { get; set; }
}