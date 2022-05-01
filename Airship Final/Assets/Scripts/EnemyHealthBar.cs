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
        healthbar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        healthbar.transform.rotation = transform.rotation = Quaternion.Euler(0,transform.parent.rotation.eulerAngles.y,0);
    }
}
