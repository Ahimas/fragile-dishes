using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FragileDishes
{
    public class FragileDishController : MonoBehaviour
    {
        [SerializeField] private Transform fragileDishesContainer;
        [SerializeField] private float explosionDelay;
        [SerializeField] private AudioController audioController;

        private List<FragileDish> _fragileDishes = new();

        private void Start()
        {
            GetFragileComponents();
            StartCoroutine(ExplosionCor(explosionDelay));
        }

        private IEnumerator ExplosionCor(float delay)
        {
            yield return new WaitForSeconds(1f);

            WaitForSeconds waiter = new WaitForSeconds(delay);

            foreach (var dish in _fragileDishes)
            {
                float power = Random.Range(150f, 450f);
                float upwardModifier = Random.Range(0.00025f, 0.0008f);

                dish.Blow(power, upwardModifier);
                audioController.PlayBrokenGlassSound();

                yield return waiter;
            }

        }

        private void GetFragileComponents()
        {
            foreach (Transform child in fragileDishesContainer)
            {
                _fragileDishes.Add(child.GetComponent<FragileDish>());
            }
        }

    }
}
