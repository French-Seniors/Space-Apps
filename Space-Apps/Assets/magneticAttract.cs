using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce = 350; 
    [Header("Résultat en temps réel")]
    public static int objectsCount = 0;
    [Header("Paramètres de la zone")]
    float radius = MenuScript.magnetForce;
    public LayerMask targetLayer;
    private SphereCollider myCollider;

    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        // Sécurité : s'assure que la sphère ne bloque pas physiquement les autres objets
        myCollider.isTrigger = true; 
    }
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
    void Update()
    {
        myCollider.radius = radius;
        // Crée une sphère invisible et compte tous les colliders du bon Layer à l'intérieur
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, radius, targetLayer);
        
        // Met à jour le compteur en permanence
        objectsCount = objectsInRange.Length - 5;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}