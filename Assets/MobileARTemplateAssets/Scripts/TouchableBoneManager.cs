using System.Collections.Generic;
using UnityEngine;

public class TouchableBoneManager : MonoBehaviour
{
    public static TouchableBoneManager Instance;

    private List<TouchableBone> allBones = new List<TouchableBone>();
    private bool isFiltered = false;

    void Awake()
    {
        Instance = this;
    }

    public void RegisterBone(TouchableBone bone)
    {
        if (!allBones.Contains(bone))
            allBones.Add(bone);
    }

    public void ShowOnlySelected(TouchableBone selected)
    {
        foreach (var bone in allBones)
        {
            bool isSelected = bone == selected;
            bone.SetTransparent(!isSelected);
        }

        isFiltered = true;
    }


    public void ShowAll()
    {
        foreach (var bone in allBones)
        {
            bone.SetTransparent(false);
        }

        isFiltered = false;
    }


    public bool IsFiltered => isFiltered;
}
