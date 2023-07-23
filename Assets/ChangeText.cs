using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    [SerializeField] TMP_Text Text;

    public void SetText(string s)
    {
        Text.text = s;
    }
}
