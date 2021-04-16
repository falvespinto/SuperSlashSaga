using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    private float frontHealthBarfill;
    private float backHealthBarfill;
    public float maxHealth = 100;
    public Image frontHealthBar;
    public Image backHealthBar;
    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }
    public void UpdateHealthUI()
    {
        frontHealthBarfill = frontHealthBar.fillAmount;
        backHealthBarfill = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
        if (backHealthBarfill >= frontHealthBarfill)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer = Time.deltaTime;
            backHealthBar.fillAmount = Mathf.Lerp(backHealthBarfill, hFraction, lerpTimer);
        }
    }
    public void SetHealth(float health)
    {
        this.health = health;
    }
}
