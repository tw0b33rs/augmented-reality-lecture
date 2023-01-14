using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlacementManagerSimple : MonoBehaviour
{
    public GameObject prefab;
    public Camera arCamera;
    public ARRaycastManager raycastManager;
    public int maxNumberOfObjects = 5;

    private int countObjects = 0;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<GameObject> placedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                Debug.Log("Hit!!!");
                Debug.Log(touch.position);

                if (countObjects < maxNumberOfObjects)
                {
                    if (raycastManager.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                    {
                        var hitPose = hits[0].pose;
                        Debug.Log(hitPose);
                        placedObjects.Add(Instantiate(prefab, hitPose.position, hitPose.rotation));
                        countObjects++;
                    }
                }
            }
        }
    }
}
