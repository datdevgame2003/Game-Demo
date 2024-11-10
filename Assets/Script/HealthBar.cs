using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    // Start is called before the first frame update
  
    public void HealthBarUpdate(float presentHealth, float maxHealth)
    {
        healthBar.fillAmount = presentHealth / maxHealth;
        
    }
}
 