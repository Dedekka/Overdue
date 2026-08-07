using UnityEngine;
using Zenject;

public class DialogTest
{
    private DialogSystem _dialogSystem;
    private int _dialogIndex;

    [Inject]
    public void Construct(DialogSystem dialogSystem)
    {
        _dialogSystem = dialogSystem;
    }

    public bool StartDialog(int dialogIndex)
    {
        bool SuccessStart = CheckCurrentDialogs(dialogIndex);

        if (SuccessStart)
        {
            _dialogSystem.StartDialogue(dialogIndex);
        }
        else
        {
            Debug.LogError("Dialog End ");
        }
        return SuccessStart;
    }

    private bool CheckCurrentDialogs(int dialogIndex)
    {
        bool isNewDialog = false;

        if (dialogIndex < 0 || dialogIndex == _dialogIndex)
        {
            return isNewDialog;
        }
        _dialogIndex = dialogIndex;
        isNewDialog = true;

        return isNewDialog;
    }
}