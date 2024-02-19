using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradiant;
    public Image fill;


    //Set la valeur de point de vie max au démarrage du jeu
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        // on met la couleur maximal sur notre gradiant 
        fill.color = gradiant.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        // on set la nouvelle couleur en fonction de la valeur de notre slider
        fill.color = gradiant.Evaluate(slider.normalizedValue);
    }

    
}
