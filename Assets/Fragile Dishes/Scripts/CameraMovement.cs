using System;
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
        
        private int _nextPositionIndex;
        private int _startCameraPositionIndex = 0;

        private void Start()
        {
            InitMoving();
        }

        private void LateUpdate()
        {
            this.transform.LookAt(lookPoint);
        }

        private void InitMoving()
        {
            _startCameraPositionIndex = Math.Clamp(_startCameraPositionIndex, 0, cameraPoints.Count - 1);
            this.transform.position = cameraPoints[_startCameraPositionIndex].position;
            _nextPositionIndex = _startCameraPositionIndex + 1;
            
            if (_nextPositionIndex == cameraPoints.Count) _nextPositionIndex = 0;
            
            MoveToPosition(cameraPoints[_nextPositionIndex].position);
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
            
            _nextPositionIndex++;
            if (_nextPositionIndex == cameraPoints.Count) _nextPositionIndex = 0;
            
            MoveToPosition(cameraPoints[_nextPositionIndex].position);
            
        }
        
    }
}
