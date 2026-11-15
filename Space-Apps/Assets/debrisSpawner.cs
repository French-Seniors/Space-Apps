using System.Collections;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    // Les crochets [] transforment la variable en une liste de plusieurs objets
    public GameObject[] debrisPrefabs; 
    public float spawnRate = 2f; 
    public float spawnWidth = 8f; 
    public float spawnDepth = 0f; 

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Vérifie qu'il y a au moins un modèle dans la liste pour éviter de faire planter le jeu
            if (debrisPrefabs.Length > 0)
            {
                // Tire un numéro au hasard entre 0 et la taille totale de ta liste
                int randomIndex = Random.Range(0, debrisPrefabs.Length);
                GameObject prefabToSpawn = debrisPrefabs[randomIndex];

                // Position aléatoire sur l'axe X
                float randomX = Random.Range(-spawnWidth, spawnWidth);
                Vector3 spawnPosition = new Vector3(randomX, transform.position.y, spawnDepth);
                
                // Fait apparaître le modèle qui a été tiré au sort
                Instantiate(prefabToSpawn, spawnPosition, Random.rotation);
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }
}