using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Health : MonoBehaviour
    {
        public float currentHealth = 100f;

        void TakeDamage(int damageAmount)
        {
            currentHealth -= damageAmount;
            if(currentHealth < 0)
            {
                Destroy(gameObject);
            }
        }

        public static void TryDamage(GameObject target, int damageAmount)
        {
            Health heth = target.GetComponent<Health>();
            if(heth != null)
            {
                heth.TakeDamage(damageAmount);
            }

        }
    }
}