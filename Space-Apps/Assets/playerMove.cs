using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    
    [Header("Réglages du Burst")]

    public float burstForce = 15f; // Puissance du dash
    public float burstCooldown = 0.3f; // Temps d'attente entre deux dashs
    
    [Header("Réglages du Tilt (Inclinaison)")]
    public float tiltAngle = 35f; // Angle maximum de l'inclinaison
    public float tiltSpeed = 10f; // Vitesse à laquelle le vaisseau se penche et se redresse

    private float nextBurstTime = 0f;
    private float currentTilt = 0f;
    private float targetTilt = 0f;

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Détection des touches pour le Burst
        if (Time.time >= nextBurstTime)
        {
            // Flèche Gauche ou touche Q/A
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A))
            {
                ExecuteBurst(-1f);
            }
            // Flèche Droite ou touche D
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                ExecuteBurst(1f);
            }
        }

        // 2. Gestion fluide du Tilt
        // Ramène doucement la cible d'inclinaison vers 0 (position droite)
        targetTilt = Mathf.Lerp(targetTilt, 0f, Time.deltaTime * tiltSpeed * 0.5f);
        
        // Applique l'inclinaison actuelle vers la cible
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);
        
        // Rotation sur l'axe Z (roulis)
        transform.rotation = Quaternion.Euler(0f, 0f, currentTilt);
    }
    void ExecuteBurst(float direction)
    {
        ResourceManager.energy -= 30f;
        // Stoppe l'élan horizontal précédent pour éviter de glisser à l'infini
        rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, rb.linearVelocity.z);
        
        // Applique une force explosive instantanée (Impulse)
        rb.AddForce(new Vector3(direction * burstForce, 0f, 0f), ForceMode.Impulse);
        
        // Définit l'inclinaison cible (négatif pour se pencher dans la direction du mouvement)
        targetTilt = -direction * tiltAngle;

        // Lance le chronomètre avant le prochain burst autorisé
        nextBurstTime = Time.time + burstCooldown;
    }
}