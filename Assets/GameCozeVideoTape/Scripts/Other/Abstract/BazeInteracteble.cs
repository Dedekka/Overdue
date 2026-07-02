using UnityEngine;

public abstract class BazeInteracteble : MonoBehaviour, IInteracteble
{
    //[Header("Settings")]
    //public bool UseEvents;
    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
    [SerializeField] private string _description;

    /// <summary>
    /// Базовое воспроизведение команты использовать
    /// </summary>
    public virtual void BaseInteract()
    {
        //if (UseEvents)
        //{
        //    GetComponent<InteractebleEvents>().OnInteract?.Invoke();
        //}
        Interact();
    }

    /// <summary>
    /// Персональное воспроизведение, команты использовать наследник должен переопределить под свою реализацию
    /// </summary>
    protected virtual void Interact()
    {
    }
}
