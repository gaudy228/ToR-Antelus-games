using System;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public event Action OnNextDialogue;

    public void NextDialogue()
    {
        OnNextDialogue?.Invoke();
    }
}
