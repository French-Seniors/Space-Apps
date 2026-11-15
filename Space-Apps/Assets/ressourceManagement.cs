using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    [Header("Valeurs actuelles")]
    float fuel = MenuScript.maxFuel;
    float maxFuel = MenuScript.maxFuel;
    
    public static float energy = 100f;
    public float maxEnergy = 100f;
    public static float finalCount;

    [Header("Paramètres")]
    float energyRegenPerSecond = MenuScript.energyRegenPerSecond; // Régénère 5 points d'énergie par seconde

    [Header("Éléments UI - Textes")]
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI debrisCountText;

    [Header("Éléments UI - Barres")]
    public Slider fuelSlider;
    public Slider energySlider;

    void Start()
    {
        if (fuelSlider != null) fuelSlider.maxValue = maxFuel;
        if (energySlider != null) energySlider.maxValue = maxEnergy;
    }

    void Awake()
    {
        energy = 100f;
    }

    void Update()
    {
        // 1. CALCULS : On régénère l'énergie en fonction du temps réel, pas des frames
        if (energy < maxEnergy)
        {
            energy += energyRegenPerSecond * Time.deltaTime;
            fuel -= 1f * Time.deltaTime;
            // Sécurité : empêche l'énergie de dépasser le maximum (ex: 100.2)
            if (energy > maxEnergy - Magnet.objectsCount*2) 
            {
                energy = maxEnergy- Magnet.objectsCount*2;
            }
            if (energy < 0)
            {
                fuel += energy/3;
                energy = 0;
            }
        }
        if (fuel <= 0)
        {
            finalCount = Magnet.objectsCount;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // 2. AFFICHAGE : On met à jour l'UI APRÈS les calculs
        if (fuelSlider != null) fuelSlider.value = fuel;
        if (energySlider != null) energySlider.value = energy;

        if (fuelText != null) fuelText.text = "FUEL " + Mathf.RoundToInt(fuel).ToString();
        if (energyText != null) energyText.text = "ENERGY " + Mathf.RoundToInt(energy).ToString();
        if (debrisCountText != null) debrisCountText.text = "DEBRIS " + Mathf.RoundToInt(Magnet.objectsCount).ToString();
    }
}