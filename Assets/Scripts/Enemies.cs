using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense{
    public class Enemy : MonoBehaviour
    {
        public Path path;
        public int index = 0;
        public float speed = 1f;
        public int damage = 1;

        void Start()
        {
            StartCoroutine(FollowPath());
        }

        IEnumerator FollowPath()
        {
            Vector3 target;
            while(path.TryGetPoint(index, out target))
            {
                Vector3 start = transform.position;

                float maxDist = Mathf.Min(speed * Time.deltaTime, (target - start).magnitude);
                transform.position = Vector3.MoveTowards(start, target, maxDist);

                if(transform.position == target) index++;
                yield return null;
            }
        }
    }
}