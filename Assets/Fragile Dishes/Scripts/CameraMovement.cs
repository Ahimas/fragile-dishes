using System.Collections;
using UnityEngine;

namespace FragileDishes
{
    public class CameraMovementController : MonoBehaviour
    {
        [SerializeField] private Transform roomCenter;

        private void Awake()
        {
            transform.position = roomCenter.position;
        }

        public void RotateToBlow(Transform target, float duration)
        {
            Quaternion startRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
            
            StartCoroutine(RotateCoroutine(startRotation, targetRotation, duration));
        }
        
        private IEnumerator RotateCoroutine(Quaternion start, Quaternion end, float duration)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                transform.rotation = Quaternion.Lerp(start, end, elapsedTime / duration);
                
                elapsedTime += Time.deltaTime;
                
                yield return null;
            }
            
            transform.rotation = end;
        }
    }
}
