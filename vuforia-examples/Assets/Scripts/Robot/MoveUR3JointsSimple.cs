using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoveUR3JointsSimple : MonoBehaviour
{
    // PlacementManagerSimpleMovement pm;
    public GameObject menuUR3;
    public GameObject ur3;
    UR3 ur3Tree;
    TMP_Dropdown dropdownUR3Joints;
    Slider sliderJointPosition;
    TMP_Text textCurrentJointPosition;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = menuUR3;
        dropdownUR3Joints = canvas.GetComponentInChildren<TMP_Dropdown>();
        sliderJointPosition = canvas.GetComponentInChildren<Slider>();
        foreach (TMP_Text item in canvas.GetComponentsInChildren<TMP_Text>())
        {
            if (item.name == "Text Current Joint Position") {
                textCurrentJointPosition = item;
            }
        }
        Debug.Log(canvas.transform.Find("Text Current Joint Position"));
        ur3Tree = ur3.GetComponent<UR3>();
        // textCurrentJointPosition = canvas.transform.Find("Text Current Joint Position").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropdownValueChanged(int value)
    {
        int indexDropdown = dropdownUR3Joints.value;
        sliderJointPosition.value = ur3Tree.JointPositions[value];
        textCurrentJointPosition.text = sliderJointPosition.value.ToString() + "°";
    }

    public void SliderJointValueChanged(float value)
    {
        int indexDropdown = dropdownUR3Joints.value;
        var jp = ur3Tree.JointPositions;
        jp[indexDropdown] = value;
        ur3Tree.JointPositions = jp;
        textCurrentJointPosition.text = value.ToString() + "°";
    }
}
