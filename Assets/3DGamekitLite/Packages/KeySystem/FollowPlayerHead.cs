using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
    public class FollowPlayerHead : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset;

        int index = 0;

        public void Awake()
        {
            offset = new Vector3(Random.Range(-.70f, .70f),
                                 Random.Range(-.70f, .70f),
                                 Random.Range(-.70f, .70f));

            // future update: make keys spiral around player?

        }

        private void LateUpdate()
        {
            if(target == null)
            {
                target = GameObject.Find("HeadTarget").transform;
            }
            if (target == null)
                return;

            transform.position = target.position + offset;
            transform.rotation = target.rotation;
        }
    } 
}
