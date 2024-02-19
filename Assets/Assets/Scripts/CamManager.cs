using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 curVelocity = Vector3.zero;
    private Vector3 offset;
    

    private void Awake()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        var targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref curVelocity, smoothTime);
    }
}
