using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Stats stats;
    public Slider slider;
    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.maxValue = stats.MaxHealth;
        slider.value = stats.Health;
    }

}
