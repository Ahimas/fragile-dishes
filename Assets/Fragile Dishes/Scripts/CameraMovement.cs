using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FragileDishes
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Transform lookPoint;
        [SerializeField] private List<Transform> cameraPoints = new List<Transform>();

        private bool _isMoving;

        private void Start()
        {
            StartCoroutine(CameraMovementCoroutine());
        }

        private void LateUpdate()
        {
            this.transform.LookAt(lookPoint);
        }

        private IEnumerator CameraMovementCoroutine()
        {
            int nextPositionIndex = 1;

            this.transform.position = cameraPoints[0].position;
            
            while (true)
            {
                if (_isMoving) continue;
                
                _isMoving = true;
                
                MoveToPosition(cameraPoints[nextPositionIndex].position);
                nextPositionIndex++;

                if (nextPositionIndex == cameraPoints.Count) nextPositionIndex = 0;
            }
        }
        
        private void MoveToPosition(Vector3 targetPosition)
        {
            Vector3 startPosition = transform.position;
            
            float distance = Vector3.Distance(startPosition, targetPosition);
            float duration = distance / moveSpeed;

            Debug.Log($"Start position: {startPosition}\nTargetPosition: {targetPosition}\nLookPoint: {lookPoint.position}");
            
            StartCoroutine(MoveCoroutine(startPosition, targetPosition, duration));
        }
        
        private IEnumerator MoveCoroutine(Vector3 start, Vector3 end, float duration)
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(start, end, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                
                yield return null;
            }
            
            transform.position = end;
            _isMoving = false;
        }
        
    }
}
