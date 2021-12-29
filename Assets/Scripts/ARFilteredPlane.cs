using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFilteredPlane : MonoBehaviour
{

    public event Action OnVerticalPlaneFound;
    public event Action OnHorizontalPlaneFound;
    public event Action OnBigPlaneFound;


    [SerializeField] private Vector2 dimensionsForBigPlane;
    private ARPlaneManager arPlaneManager;
    private List<ARPlane> arPlanes;
    

    private void OnEnable() {
        arPlanes = new List<ARPlane>();
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChnaged;
    }

    private void OnDisable() {
        arPlaneManager.planesChanged -= OnPlanesChnaged;
    }

    private void OnPlanesChnaged(ARPlanesChangedEventArgs obj)
    {
        if(obj.added != null && obj.added.Count > 0) {
            arPlanes.AddRange(obj.added);
        }

        foreach (ARPlane plane in arPlanes)
        {
            if((plane.extents.x * plane.extents.y) >= 0.1f){

                if(plane.alignment.IsVertical()) {
                    if(OnVerticalPlaneFound != null){
                        OnVerticalPlaneFound.Invoke();
                    }
                } 
                else {
                    if(OnHorizontalPlaneFound != null){
                        OnHorizontalPlaneFound.Invoke();
                    }
                }
            }

            if(plane.extents.x >= dimensionsForBigPlane.x && plane.extents.y >= dimensionsForBigPlane.y)
            {
                if(OnBigPlaneFound != null){
                        OnBigPlaneFound.Invoke();
                }
            }
        }

    }
}
