using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTaptoPlace : MonoBehaviour
{

    public GameObject spawnPrefab; // This is the prefab object that will be instantiated when you tap on the screen


    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject spawnedPrefabObj;


    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    
    void Update()
    {
        if(spawnedPrefabObj == null)
        {
            // Then do your thing!

            if (Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;

                if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;

                    spawnedPrefabObj = Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);
                }
            }

        }

        
    }
}
