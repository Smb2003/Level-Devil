using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float damage;
    [SerializeField] private AudioClip SpikeHurtSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(SpikeHurtSound);
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    
}
