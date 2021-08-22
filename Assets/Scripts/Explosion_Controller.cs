using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Controller : MonoBehaviour
{
    private ParticleSystem removeParticle;
    
    private void Start() {
        removeParticle = transform.GetComponent<ParticleSystem>();        
    }

    private void Update() {
        if (!removeParticle.IsAlive())
        {
             Destroy(gameObject);
        }
    }
   }
