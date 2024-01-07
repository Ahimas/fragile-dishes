using Unity.VisualScripting;
using UnityEngine;

namespace FragileDishes
{
    /// <summary>
    /// FragileDish — the core class that blows up the prepared models.
    /// </summary>
    public class FragileDish : MonoBehaviour
    {
        private GameObject _solidObject;
        private Transform _fragmentsContainer;
        private Vector3 _explosionPos;
        private static float _delay = 5f;

        private void Start()
        {
            InitVariables();
        }

        /// <summary>
        /// Blows up the prepared model with given powers.
        /// </summary>
        /// <param name="power"></param>
        /// <param name="upwardsModifier"></param>
        public void Blow(float power, float upwardsModifier)
        {
            _solidObject.SetActive(false);
            _fragmentsContainer.gameObject.SetActive(true);

            foreach (Transform child in _fragmentsContainer)
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
                switch (child.name)
                {
                    case "Solid":
                        _solidObject = child.gameObject;
                        break;
                    case "FragmentsContainer":
                        _fragmentsContainer = child;
                        break;
                }
            }
        }
    }
}
