using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artManager : Singleton<artManager>
{

    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        BEACH,
        SNOW
    }
    public List<artSetup> artSetups;

    public artSetup getSetupByType(ArtType artType)
    {
        return artSetups.Find(i => i.artType == artType);

    }

}
[System.Serializable]
public class artSetup
{
    public artManager.ArtType artType;
    public GameObject gameObject;
}
