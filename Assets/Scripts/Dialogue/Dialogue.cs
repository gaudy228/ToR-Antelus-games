using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour, IInteract
{
    [SerializeField] private Pause _pause;
    [SerializeField] private DialogueSO _dialogueSO;
    [SerializeField] private List<Camera> _cameras = new List<Camera>();
    [SerializeField] private List<int> _turningOnNewCameras = new List<int>();
    [SerializeField] private DialogueSystem _dialogueSystem;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    private int _curDialogueIndex;
    private int _curTurningOnNewCamerasIndex;
    private Camera _curCamera;

    public void Interact()
    {
        StartDialogue();
    }

    private void StartDialogue()
    {
        _curDialogueIndex = 0;

        _curTurningOnNewCamerasIndex = 0;

        _dialogueSystem.OnNextDialogue += NextDialogue;

        _pause.GamePause();

        _dialogueSystem.gameObject.SetActive(true);

        _cameras[_curTurningOnNewCamerasIndex].gameObject.SetActive(true);
        _curCamera = _cameras[_curTurningOnNewCamerasIndex];

        _dialogueText.text = _dialogueSO.DialogueTexts[_curDialogueIndex];

        _curTurningOnNewCamerasIndex++;
    }

    private void NextDialogue()
    {
        _curDialogueIndex++;

        if(_curDialogueIndex >= _dialogueSO.DialogueTexts.Count)
        {
            EndDialogue();
            return;
        }

        if(_curTurningOnNewCamerasIndex < _turningOnNewCameras.Count)
        {
            if (_curDialogueIndex == _turningOnNewCameras[_curTurningOnNewCamerasIndex])
            {
                _curCamera.gameObject.SetActive(false);

                _cameras[_curTurningOnNewCamerasIndex].gameObject.SetActive(true);

                _curCamera = _cameras[_curTurningOnNewCamerasIndex];

                _curTurningOnNewCamerasIndex++;
            }
        }
        _dialogueText.text = _dialogueSO.DialogueTexts[_curDialogueIndex];

    }

    private void EndDialogue()
    {
        _dialogueSystem.OnNextDialogue -= NextDialogue;

        _dialogueSystem.gameObject.SetActive(false);

        _curCamera.gameObject.SetActive(false);

        _pause.GameUnPause();
    }

    private void OnDisable()
    {
        _dialogueSystem.OnNextDialogue -= NextDialogue;
    }
}
