using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteredPlaneCanvas : MonoBehaviour
{
    [SerializeField] private Toggle verticalPlaneToggle;
    [SerializeField] private Toggle horizontalPlaneToggle;
    [SerializeField] private Toggle bigPlaneToggle;
    [SerializeField] private Button startButton;

    private ARFilteredPlane arFilteredPlane;
    public bool VerticalPlaneToggle 
    { 
        get => verticalPlaneToggle.isOn;
        set 
        {
            verticalPlaneToggle.isOn = value;
            CheckAllPlanes();    
        } 
    }

    public bool HorizontalPlaneToggle 
    { 
        get => horizontalPlaneToggle.isOn;
        set 
        {
            horizontalPlaneToggle.isOn = value;
            CheckAllPlanes();    
        } 
    }

    public bool BigPlaneToggle 
    { 
        get => bigPlaneToggle.isOn;
        set 
        {
            bigPlaneToggle.isOn = value;
            CheckAllPlanes();    
        } 
    }

    private void OnEnable() {
        arFilteredPlane = FindObjectOfType<ARFilteredPlane>();

        arFilteredPlane.OnVerticalPlaneFound += () => VerticalPlaneToggle = true;
        arFilteredPlane.OnHorizontalPlaneFound += () => HorizontalPlaneToggle = true;
        arFilteredPlane.OnBigPlaneFound += () => BigPlaneToggle = true;
    }

    private void OnDisable() {
        arFilteredPlane.OnVerticalPlaneFound -= () => VerticalPlaneToggle = true;
        arFilteredPlane.OnHorizontalPlaneFound -= () => HorizontalPlaneToggle = true;
        arFilteredPlane.OnBigPlaneFound -= () => BigPlaneToggle = true;
    }

    private void CheckAllPlanes()
    {
        if(VerticalPlaneToggle && HorizontalPlaneToggle && BigPlaneToggle) {
            startButton.interactable = true;
        }
    }    

}
