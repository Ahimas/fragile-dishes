using UnityEngine;

namespace FragileDishes
{
    /// <summary>
    /// DishPlaceholder — place the FragileDish object to its children objects.
    /// </summary>
    public class DishPlaceholder : MonoBehaviour
    {
        private void Start()
        {
            GetDishes();
        }
        
        /// <summary>
        /// Places dishes from SpawnManager at its children positions.
        /// </summary>
        private void GetDishes()
        {
            foreach (Transform child in this.transform)
            {
                SpawnManager.Instance.InstantiateRandomFragileDish(child);
            }
        }
        
    }
}
