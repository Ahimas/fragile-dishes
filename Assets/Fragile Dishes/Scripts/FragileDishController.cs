using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FragileDishes
{
    /// <summary>
    /// Controls the automatic explosion of each FragileDish contained into its internal list. 
    /// </summary>
    public class FragileDishController : MonoBehaviour
    {
        [SerializeField] private float explosionDelay;
        [SerializeField] private AudioController audioController;

        private List<FragileDish> _fragileDishes = new();

        private void Start()
        {
            //StartCoroutine(ExplosionCor(explosionDelay));
        }

        /// <summary>
        /// Adds the FragileDish object to its internal list for further explosions.
        /// </summary>
        /// <param name="fragileDish"></param>
        public void AddFragileDish(FragileDish fragileDish)
        {
            _fragileDishes.Add(fragileDish);
        }
        
        /// <summary>
        /// Invoke the FragileDish explosions with random force.
        /// </summary>
        /// <param name="delay">Pause between explosions.</param>
        /// <returns></returns>
        private IEnumerator ExplosionCor(float delay)
        {
            yield return new WaitForSeconds(1f);

            RandomizeListOrder();
            
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

        /// <summary>
        /// Randomly mix the list content order.
        /// </summary>
        private void RandomizeListOrder()
        {
            int n = _fragileDishes.Count;
            int limit = n - 1;
            
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, limit);

                (_fragileDishes[k], _fragileDishes[n]) = (_fragileDishes[n], _fragileDishes[k]);
            }
        }
    }
}
