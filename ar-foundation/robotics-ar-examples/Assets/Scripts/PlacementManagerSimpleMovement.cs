using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Linq;

public class PlacementManagerSimpleMovement : MonoBehaviour
{
    public GameObject prefab;
    public Camera arCamera;
    public ARRaycastManager raycastManager;
    public GameObject ur3Menu;

    private int countObjects = 0;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<GameObject> placedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ur3Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                bool isOverUI = touchPosition.IsPointOverUIObject();

                if (isOverUI) {
                    // Debug.Log("Over UI");
                    return;
                }

                Ray ray = arCamera.ScreenPointToRay(touch.position);
                Debug.Log("Hit!!!");

                if (countObjects < 1)
                {
                    if (raycastManager.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                    {
                        var hitPose = hits[0].pose;
                        placedObjects.Add(Instantiate(prefab, hitPose.position, hitPose.rotation));
                        placedObjects.Last().AddComponent<UR3>();
                        countObjects++;
                        ur3Menu.SetActive(true);
                    }
                }
            }
        }
    }

    public GameObject GetRobot()
    {
        if (placedObjects.Count > 0)
        {
            return placedObjects[0];
        }
        return new GameObject();
    }
}
