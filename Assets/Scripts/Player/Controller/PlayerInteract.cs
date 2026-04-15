using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private LayerMask interactLayer;

    public void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, interactLayer))
        {
            if(hit.collider.TryGetComponent(out IInteract interact))
            {
                interact.Interact();
            }
        }
    }
}
