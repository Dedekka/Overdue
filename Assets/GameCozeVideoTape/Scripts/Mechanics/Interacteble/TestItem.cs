using UnityEngine;

public class TestItem : BazeInteracteble
{
    protected override void Interact()
    {
       gameObject.SetActive(false);
    }
}