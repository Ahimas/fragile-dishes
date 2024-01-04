using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FragileDishes
{
    public class FragileDishController : MonoBehaviour
    {
        [SerializeField] private Transform fragileDishesContainer;
        [SerializeField] private float explosionDelay;

        private List<FragileDish> _fragileDishes = new();

        private void Start()
        {
            GetExplosionComponents();
            StartCoroutine(ExplosionCor(explosionDelay));
        }

        private IEnumerator ExplosionCor(float delay)
        {
            yield return new WaitForSeconds(1f);

            WaitForSeconds waiter = new WaitForSeconds(delay);

            foreach (var dish in _fragileDishes)
            {
                float power = Random.Range(50f, 550f);
                float upwardModifier = Random.Range(0.00025f, 0.0008f);

                dish.Blow(power, upwardModifier);

                yield return waiter;
            }

        }

        private void GetExplosionComponents()
        {
            foreach (Transform child in fragileDishesContainer)
            {
                _fragileDishes.Add(child.GetComponent<FragileDish>());
            }
        }

    }
}
