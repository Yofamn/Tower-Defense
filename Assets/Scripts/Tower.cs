using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private List<GameObject> enemiesInRange = new List<GameObject>();
        public Tower_SO towerType;
        private bool firing = false;

        IEnumerator DamageEnemyTarget()
        {
            firing = true;

            while(enemiesInRange.Count > 0)
            {
                if(!enemiesInRange[0]) 
                {
                    enemiesInRange.RemoveAt(0);
                }
                else
                {
                    Health.TryDamage(enemiesInRange[0], towerType.damage);
                }
                

                yield return new WaitForSeconds(towerType.fireRate);
            }

            firing = false;
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Enemy")) enemiesInRange.Add(other.gameObject);

            if(!firing) StartCoroutine(DamageEnemyTarget());
        }

        void OnTriggerExit(Collider other)
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }
}