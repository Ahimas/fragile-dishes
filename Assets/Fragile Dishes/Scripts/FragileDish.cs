using System;
using Unity.VisualScripting;
using UnityEngine;

namespace FragileDishes
{

    [Serializable]
    public class FragileDish : MonoBehaviour
    {
        private GameObject _fullObject;
        private Transform _cells;
        private Vector3 _explosionPos;
        private float _delay = 5f;

        private void Start()
        {
            InitVariables();
        }

        public void Blow(float power, float upwardsModifier)
        {
            _fullObject.SetActive(false);
            _cells.gameObject.SetActive(true);

            foreach (Transform child in _cells)
            {
                var rb = child.AddComponent<Rigidbody>();
                var cl = child.AddComponent<BoxCollider>();

                rb.AddExplosionForce(power, _explosionPos, 0, upwardsModifier);
                rb.useGravity = true;

                Destroy(rb, _delay);
                Destroy(cl, _delay);
            }
        }

        private void InitVariables()
        {
            _explosionPos = transform.position;

            foreach (Transform child in this.transform)
            {
                if (child.name.Equals("FULL")) _fullObject = child.gameObject;
                if (child.name.Equals("CELLS")) _cells = child;
            }
        }
    }
}
