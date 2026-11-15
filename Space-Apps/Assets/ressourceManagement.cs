using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [Header("Valeurs actuelles")]
    public float fuel = 100f;
    public float maxFuel = 100f;
    
    public static float energy = 100f;
    public float maxEnergy = 100f;

    [Header("Paramètres")]
    public float energyRegenPerSecond = 10f; // Régénère 5 points d'énergie par seconde

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

        // 2. AFFICHAGE : On met à jour l'UI APRÈS les calculs
        if (fuelSlider != null) fuelSlider.value = fuel;
        if (energySlider != null) energySlider.value = energy;

        if (fuelText != null) fuelText.text = "Fuel : " + Mathf.RoundToInt(fuel).ToString();
        if (energyText != null) energyText.text = "Energy : " + Mathf.RoundToInt(energy).ToString();
        if (debrisCountText != null) debrisCountText.text = "Debris : " + Mathf.RoundToInt(Magnet.objectsCount).ToString();
    }
}