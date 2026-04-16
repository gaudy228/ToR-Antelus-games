using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
    [TextArea(3, 5)]
    public List<string> DialogueTexts = new List<string>();
}
