using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoveUR3JointsSimple : MonoBehaviour
{
    PlacementManagerSimpleMovement pm;
    TMP_Dropdown dropdownUR3Joints;
    Slider sliderJointPosition;
    TMP_Text textCurrentJointPosition;

    // Start is called before the first frame update
    void Start()
    {
        pm = gameObject.GetComponent<PlacementManagerSimpleMovement>();

        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas UR3");
        dropdownUR3Joints = canvas.GetComponentInChildren<TMP_Dropdown>();
        sliderJointPosition = canvas.GetComponentInChildren<Slider>();
        foreach (TMP_Text item in canvas.GetComponentsInChildren<TMP_Text>())
        {
            if (item.name == "Text Current Joint Position") {
                textCurrentJointPosition = item;
            }
        }
        Debug.Log(canvas.transform.Find("Text Current Joint Position"));
        // textCurrentJointPosition = canvas.transform.Find("Text Current Joint Position").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropdownValueChanged(int value)
    {
        int indexDropdown = dropdownUR3Joints.value;
        sliderJointPosition.value = pm.GetRobot().GetComponent<UR3>().JointPositions[value];
        textCurrentJointPosition.text = sliderJointPosition.value.ToString() + "°";
    }

    public void SliderJointValueChanged(float value)
    {
        int indexDropdown = dropdownUR3Joints.value;
        GameObject currentPrefab = pm.GetRobot();
        UR3 ur3 = currentPrefab.GetComponent<UR3>();

        var jp = ur3.JointPositions;
        jp[indexDropdown] = value;
        ur3.JointPositions = jp;
        textCurrentJointPosition.text = value.ToString() + "°";
    }
}
