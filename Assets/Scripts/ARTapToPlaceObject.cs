using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{

    public GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;
    private ARRaycastManager _aRRaycastManager;
    private Vector2 touchPosition;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake() {
        _aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition){

        if(Input.touchCount > 0) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    private void Update() {
        if(TryGetTouchPosition(out Vector2 touchPosition)) {
            if(_aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)){
                var hitPose = hits[0].pose;

                if(spawnedObject == null) {
                    spawnedObject = Instantiate<GameObject>(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                } else {
                    spawnedObject.transform.position = hitPose.position;
                }
            }
        }
    }

}
