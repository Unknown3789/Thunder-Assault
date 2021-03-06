using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ship_Stats
{
    public float maxHealth;
    public float currentHealth;
}

public class Ship_Controller : MonoBehaviour
{
    Rigidbody rb;

    public Ship_Stats stats;

    public GameObject bullet;
    public Transform[] firePoints = new Transform[2];
    public float fireRate;
    private float nextFire;
    
    public GameObject explosionPrefab;

    public float moveSpeed;
    public float tiltAngle;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

        stats.currentHealth = stats.maxHealth;

        nextFire = 1 / fireRate;
    }

    private void Update()
    {
        if (stats.currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        rb.velocity = movement * moveSpeed;

        rb.rotation = Quaternion.Euler(Vector3.forward * moveLR * -tiltAngle);

        bool fireButton = Input.GetButton("Fire1");

        Collider[] shipColliders = transform.GetComponentsInChildren<Collider>();

        if (fireButton)
        {
            nextFire -= Time.fixedDeltaTime;
            if (nextFire <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject bulletClone = Instantiate(bullet, firePoints[i].position, Quaternion.identity);        
                                       
                }
                nextFire += 1 / fireRate;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag.Equals("Asteroid"))
      {
          stats.currentHealth -= collision.transform.GetComponent<Asteroid_Controller>().stats.rockDamage;
          Destroy(collision.gameObject);
      }  
    }
}
