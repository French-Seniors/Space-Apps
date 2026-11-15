using UnityEngine;
using UnityEngine.UI; // Obligatoire pour utiliser les composants UI comme "Image"

public class RandomImageSelector : MonoBehaviour
{
    // Tableau qui va contenir tes 5 images
    public Sprite[] imagesArray;

    // Le composant qui va afficher l'image sur ton écran
    public Image displayImage; 

    void Start()
    {
        // Appelle la fonction dès le lancement du jeu
        SelectRandomImage();
    }

    public void SelectRandomImage()
    {
        // Sécurité : on vérifie que le tableau n'est pas vide
        if (imagesArray.Length > 0)
        {
            // Génère un nombre aléatoire entre 0 et la taille du tableau (5)
            int randomIndex = Random.Range(0, imagesArray.Length);

            // Change le sprite actuel par celui tiré au sort
            displayImage.sprite = imagesArray[randomIndex];
        }
        else
        {
            Debug.LogWarning("Aucune image n'a été assignée dans le tableau !");
        }
    }
}