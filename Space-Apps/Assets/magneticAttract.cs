using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce = 200f; 

    void OnTriggerStay(Collider other)
    {
        // Vérifie d'abord si l'objet qui entre possède l'étiquette "Debris"
        if (other.CompareTag("IsPulledByMagnet"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            
            if (rb != null)
            {
                Vector3 direction = transform.position - other.transform.position;
                rb.AddForce(direction.normalized * magnetForce);
            }
        }
    }
}