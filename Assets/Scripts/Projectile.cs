using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float bulletForce = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get rigidbody
        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletForce;
        // Destroy after 2 seconds
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter ???? : " + other.gameObject.name);

        // if (other.gameObject.CompareTag("Destructible"))
        // {
        //     Destroy(other.gameObject, 2);
        //     Destroy(this.gameObject);
        // }

        if (other.gameObject.TryGetComponent(out Destructible objective))
        {
            objective.TakeDamage(5);
        }
        
    }

    private void OnCollisionStay(Collision other)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionExit(Collision other)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
