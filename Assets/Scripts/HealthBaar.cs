using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBaar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthbar;

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthbar.fillAmount = playerHealth.currentHealth / 10; // mtlb ktne dekhany hn heart, jaise hmne 3 dekhaye tu value 0.3 thi tu issi se hui, (playerHealth.currentHealth == 3 ky hai) and ussy 10 sy divide kreinge tu 0.3 ayega.

    }


}
