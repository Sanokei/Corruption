using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{
    public Camera maincamera;
    public RectTransform yesrect;
    public RectTransform norect;
    public static ChoicesManager Instance;
    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }
}
