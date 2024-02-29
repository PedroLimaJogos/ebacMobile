using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorManager : Singleton<colorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorByType(artManager.ArtType artType)
    {


        var setup = colorSetups.Find(i => i.artType == artType);


        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color", setup.colors[i]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public artManager.ArtType artType;
    public List<Color> colors;
}