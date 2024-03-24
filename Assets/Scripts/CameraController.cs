using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [field: SerializeField]
    private Camera Camera { get; set; }

    [field: SerializeField]
    private Transform ToFollow { get; set; }

    [field: SerializeField, Range(0.0f, 10.0f)]
    private float Smoothness { get; set; }

    private void Update()
    {
        Vector3 targetPosition = new(ToFollow.position.x, ToFollow.position.y, Camera.transform.position.z);
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, targetPosition, Smoothness * Time.deltaTime);
    }
}
