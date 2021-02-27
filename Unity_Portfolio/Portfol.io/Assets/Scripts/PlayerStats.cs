using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public UnityEvent deathAction;

    public int maxLife = 100;
    public int currentLife;

    private void Update()
    {
        if (currentLife <= 0)
        {
            deathAction.Invoke();
            currentLife = maxLife;
        }
    }

    void Start()
    {
        currentLife = maxLife;   
    }

    public void TakeDamage(int amount)
    {
        currentLife -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
            return;

        Projectile newProj = other.gameObject.GetComponent<Projectile>();
        if (newProj == null)
        {
            return;
        }

        int damage = newProj.damage;
        TakeDamage(damage);
        Destroy(other.gameObject);
    }

}
