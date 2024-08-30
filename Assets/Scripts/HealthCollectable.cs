using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float HealthValue;
    [SerializeField] private AudioClip HealthSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(HealthSound);
            collision.GetComponent<Health>().AddHealth(HealthValue);
            gameObject.SetActive(false);
        }
    }
}
