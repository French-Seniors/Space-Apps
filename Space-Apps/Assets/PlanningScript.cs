using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class PlanningScript : MonoBehaviour
{

    
        public TMP_Text maxFuel;
        public TMP_Text energyRegenPerSecond;
        public TMP_Text magnetForce;
        public TMP_Text money;

        Vector3 baseFuel = new Vector3(1f,1f,1f);
        Vector3 baseWing = new Vector3(1f,1f,1f);
        Vector3 baseMagnet = new Vector3(20f,20f,20f);

    public void Update()
    {
        maxFuel.text = $"FUEL CAPACITY LVL {MenuScript.maxFuel/10-4}";
        energyRegenPerSecond.text = $"ENERGY PRODUCTION LVL {MenuScript.energyRegenPerSecond-4}";
        magnetForce.text = $"MAGNET POWER LVL {MenuScript.magnetForce-4}";
        money.text = $"${MenuScript.money}M";
    }

    public void StartMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnergyProduction()
    {
        if (MenuScript.money >= 10f)
        {
            MenuScript.energyRegenPerSecond += 1f;
            MenuScript.money -= 10f;
        }
    }

    public void FuelCapacity()
    {
        if (MenuScript.money >= 10f)
        {
            MenuScript.maxFuel += 10f;
            MenuScript.money -= 10f;
        }
    }

    public void MagnetPower()
    {
        if (MenuScript.money >= 10f)
        {
            MenuScript.magnetForce += 1f;
            MenuScript.money -= 10f;
        }
    }

    public void FuelScaling()
    {
        MenuScript.fuelScale = baseFuel*((MenuScript.maxFuel/10-4)*0.025f + 1f);
    }

    public void MagnetScaling()
    {
        MenuScript.magnetScale = baseMagnet*((MenuScript.magnetForce-4)*0.025f + 1f);
    }

    public void WingScaling()
    {
        MenuScript.wingScale = baseWing*((MenuScript.energyRegenPerSecond-4)*0.025f + 1f);
    }
}
