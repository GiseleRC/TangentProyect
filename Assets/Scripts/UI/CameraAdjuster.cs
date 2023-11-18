using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraAdjuster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] float levelSize = 10;

    void OnEnable()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        float widthDiff = levelSize / Screen.width;

        float cameraSize = widthDiff * Screen.height * 1f;

        if (_camera.orthographic) _camera.orthographicSize = cameraSize;
        else _camera.fieldOfView = cameraSize;
    }
}
