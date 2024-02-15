using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [field: SerializeField]
    public Camera Camera { get; private set; }

    [field: SerializeField]
    public Transform ToFollow { get; private set; }

    [field: SerializeField, Range(0.0f, 10.0f)]
    public float Smoothness { get; private set; }

    private void Update()
    {
        Vector3 targetPosition = new(ToFollow.position.x, ToFollow.position.y, Camera.transform.position.z);
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, targetPosition, Smoothness * Time.deltaTime);
    }
}
