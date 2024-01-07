using System.Collections.Generic;
using UnityEngine;

namespace FragileDishes
{
    /// <summary>
    /// Provides the prefabs of FragileDishes.
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        public static SpawnManager Instance;

        [SerializeField] private FragileDishController fragileDishController;
        [SerializeField] private List<GameObject> fragilePrefabs;
        
        private void Awake()
        {
            Instance = this;
        }

        /// <summary>
        /// Instantiate the random FragileDish object at given position.
        /// </summary>
        /// <param name="position"></param>
        public void InstantiateRandomFragileDish(Transform position)
        {
            int index = Random.Range(0, fragilePrefabs.Count);
            FragileDish fragileDish = Instantiate(fragilePrefabs[index], position).GetComponent<FragileDish>();
            
            fragileDishController.AddFragileDish(fragileDish);
            
        }
    }
}
