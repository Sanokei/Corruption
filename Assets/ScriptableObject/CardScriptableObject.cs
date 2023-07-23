using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "CardScriptableObject", order = 1)]
public class CardScriptableObject : ScriptableObject
{
    public string CardText = "";
    // number of countries to damage
    public int DamageCountries = 0;
    // adds to the funds
    public long ChangeWarBy = 0;
    public int ChangeTaxBy = 0;
    // change by positive or negative
    public long ChangeWelfareBy = 0;
    public long ChangeCentralBankBy = 0;
    public long ChangeElectionFundBy = 0;

}
