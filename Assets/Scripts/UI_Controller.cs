using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    public Ship_Controller shipController;

    public Slider healthBar;
    public Image healthBarFill;
    public Color[] fillColor = new Color[3];

    private void Start() {
        healthBar.wholeNumbers = true;
        healthBar.minValue = 0;

        fillColor[0] = new Color(0, 255, 0);
        fillColor[1] = new Color(255, 194, 0);
        fillColor[2] = new Color(255, 0, 0);
    }

    public void Update() {
        healthBar.maxValue = shipController.stats.maxHealth;
        healthBar.value = shipController.stats.currentHealth;

        healthBarFill.color = fillColor[0];
        if (healthBar.value <= shipController.stats.maxHealth / 2) healthBarFill.color = fillColor[1];
        if (healthBar.value <= shipController.stats.maxHealth / 10) healthBarFill.color = fillColor[2];
    }
}
