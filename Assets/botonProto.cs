using UnityEngine;
using UnityEngine.Events;

public class botonProto : MonoBehaviour
{
    public UnityEvent onTriggerEnterEvent;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("coso"))
        {
            onTriggerEnterEvent.Invoke();
        }
    }
}