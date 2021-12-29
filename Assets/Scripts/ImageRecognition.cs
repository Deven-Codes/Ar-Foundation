using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager _aRTrackedImageManager;

    private void Awake() => _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();

    private void OnEnable() {
        _aRTrackedImageManager.trackedImagesChanged += OnImageChange;
    }

    private void OnDisable() {
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChange;
    }

    private void OnImageChange(ARTrackedImagesChangedEventArgs obj)
    {
        foreach( var trackedImage in obj.added) {
            Debug.Log(trackedImage.name);
        }
    }
}
