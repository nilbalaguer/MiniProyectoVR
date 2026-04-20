using UnityEngine;
using UnityEngine.Events;

public class botonProto : MonoBehaviour
{
    public UnityEvent onTriggerEnterEvent;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("coso"))
        {
            // Destroy(other.gameObject);
            onTriggerEnterEvent.Invoke();
        }
    }
}