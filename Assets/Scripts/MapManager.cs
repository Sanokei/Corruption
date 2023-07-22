using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    // int is corruption level
    private uint MidLevel;
    [SerializeField] Image Middle;

    [SerializeField] Image East; // east
    [SerializeField] Image North; // north
    [SerializeField] Image South; // south
    [SerializeField] Image West; // west
    
    public static MapManager Instance;

    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }


}
