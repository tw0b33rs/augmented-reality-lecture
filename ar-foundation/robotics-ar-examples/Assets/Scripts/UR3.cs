using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UR3 : MonoBehaviour
{
    private static int jointsCount = 6;
    private float[] jointPositions = new float[jointsCount];
    private static float[] jointsMax = new float[jointsCount];
    private static float[] jointsMin = new float[jointsCount];
    // public GameObject menu;

    // private GameObject 
    

    public float[] JointPositions
    {
        get
        {
            return jointPositions;
        }
        set
        {
            jointPositions = value;
            UpdateJointPositions();
        }
    }
    private GameObject[] jointPositionBody = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        // Get all children of UR3 game object
        var ur3Children = gameObject.GetComponentsInChildren<Transform>();
 
        // Set up joint ranges according to documentation
        jointsMax = Enumerable.Repeat(360f, jointsCount).ToArray();
        jointsMin = Enumerable.Repeat(-360f, jointsCount).ToArray();

        // Initialize joints
        for (int i = 0; i < ur3Children.Length; i++)
        {
            if (ur3Children[i].name == "Link1.001")
            {
                jointPositionBody[0] = ur3Children[i].gameObject;
            }
            else if (ur3Children[i].name == "Link2.001")
            {
                jointPositionBody[1] = ur3Children[i].gameObject;
            }
            else if (ur3Children[i].name == "Link3.001")
            {
                jointPositionBody[2] = ur3Children[i].gameObject;
            }
            else if (ur3Children[i].name == "Link4.002")
            {
                jointPositionBody[3] = ur3Children[i].gameObject;
            }
            else if (ur3Children[i].name == "Link5.001")
            {
                jointPositionBody[4] = ur3Children[i].gameObject;
            }
            else if (ur3Children[i].name == "Link6.001")
            {
                jointPositionBody[5] = ur3Children[i].gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateJointPositions()
    {
        for (int i = 0; i < 6; i++)
        {
            var orientation = jointPositionBody[i].transform.localEulerAngles;
            orientation.x = 0;
            orientation.y = 0;
            orientation.z = 0;

            switch (i)
            {
                case 0:
                    orientation.y = (-1) * jointPositions[i] + 90f;
                    break;
                case 1:
                    orientation.z = jointPositions[i];
                    break;
                case 2:
                    orientation.z = jointPositions[i];
                    break;
                case 3:
                    orientation.z = jointPositions[i];
                    break;
                case 4:
                    orientation.y = (-1) * jointPositions[i];
                    break;
                case 5:
                    orientation.z = jointPositions[i];
                    break;
            }

            // Update joint positions of game object
            jointPositionBody[i].transform.localEulerAngles = orientation;
        }
    }
}
