using UnityEngine;

public class Tutor : MonoBehaviour
{
    [SerializeField] private Pause _pause;
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField] private GameObject _tutorPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMaskUtil.ContainsLayer(_playerLayerMask, other.gameObject))
        {
            StartTutor();
        }
    }

    private void StartTutor()
    {
        _pause.GamePause();
        _tutorPanel.SetActive(true);
    }

    public void EndTutor()
    {
        _pause.GameUnPause();
        Destroy(_tutorPanel);
        Destroy(gameObject);
    }
}
