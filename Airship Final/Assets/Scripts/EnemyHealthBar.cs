using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthbar;
    public Color low;
    public Color high;
    public Vector3 offset;

    public void SetHealth(float health, float maxHealth) {
        healthbar.gameObject.SetActive(health < maxHealth);
        healthbar.value = health;
        healthbar.maxValue = maxHealth;

        healthbar.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, healthbar.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.parent.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        if (healthbar.value != 1)
        {
            healthbar.gameObject.SetActive(onScreen);
        }
        
        healthbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);

        transform.LookAt(GameObject.Find("Main Camera").transform);
    }
}
