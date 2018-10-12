using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour {

    public Stat strength;
    public Stat maxHealth;
    public Stat aggression;
    public Stat gather;
    public Stat food; //how much food is on their person

    public int currentHealth { get; private set; }

    private void Awake ()
    {
        currentHealth = maxHealth.GetValue();
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");
    }

    public void TakeFood (int amount)
    {
        food.SetValue(food.GetValue() - amount);
    }

    public virtual void Die ()
    {

    }
}
