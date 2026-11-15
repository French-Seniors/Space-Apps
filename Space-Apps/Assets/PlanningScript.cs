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
        public TMP_Text price1;
        public TMP_Text price2;
        public TMP_Text price3;
        public TMP_Text percent;

        Vector3 baseFuel = new Vector3(1f,1f,1f);
        Vector3 baseWing = new Vector3(1f,1f,1f);
        Vector3 baseMagnet = new Vector3(20f,20f,20f);

    public void Update()
    {
        maxFuel.text = $"FUEL CAPACITY LVL {MenuScript.maxFuel/10-4}";
        energyRegenPerSecond.text = $"ENERGY PRODUCTION LVL {MenuScript.energyRegenPerSecond-4}";
        magnetForce.text = $"MAGNET POWER LVL {MenuScript.magnetForce-4}";
        money.text = $"${MenuScript.money.ToString("F2")}M";
        price1.text = $"${MenuScript.price.ToString("F2")}M";
        price2.text = $"${MenuScript.price.ToString("F2")}M";
        price3.text = $"${MenuScript.price.ToString("F2")}M";
        percent.text = $"{(MenuScript.totalCleared/500).ToString("F2")}% OF SPACE";
    }

    public void StartMission()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnergyProduction()
    {
        if (MenuScript.money >= MenuScript.price)
        {
            MenuScript.energyRegenPerSecond += 1f;
            MenuScript.money -= MenuScript.price;
            MenuScript.price *= 1.2f;
        }
    }

    public void FuelCapacity()
    {
        if (MenuScript.money >= MenuScript.price)
        {
            MenuScript.maxFuel += 10f;
            MenuScript.money -= MenuScript.price;
            MenuScript.price *= 1.2f;
        }
    }

    public void MagnetPower()
    {
        if (MenuScript.money >= MenuScript.price)
        {
            MenuScript.magnetForce += 1f;
            MenuScript.money -= MenuScript.price;
            MenuScript.price *= 1.2f;
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
