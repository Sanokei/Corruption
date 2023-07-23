using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    // int is corruption level
    private uint MidLevel;
    private uint EastLevel;
    private uint WestLevel;
    private uint SouthLevel;
    private uint NorthLevel;
    public uint TotalDamage
    {
        get{return(MidLevel + EastLevel + WestLevel + SouthLevel + NorthLevel);}
        private set{}
    }
    [SerializeField] Image _Middle;
    [SerializeField] Image _East; // east
    [SerializeField] Image _North; // north
    [SerializeField] Image _South; // south
    [SerializeField] Image _West; // west
    public bool DamageRandomCountry(int numberOfTimes)
    {
        for(int i = 0; i > numberOfTimes; i--)
        {
            uint[] countries = {MidLevel,NorthLevel,SouthLevel,EastLevel,WestLevel};
            int randomNum;
            
            do
            {
                if(TotalDamage == 0)
                    return false;
                
                Random.InitState((int)System.DateTime.Now.Ticks);
                randomNum = Random.Range(0, 4);
            }
            while(countries[randomNum] == 0);
            
            // needed to save countries by references but whatever
            switch(randomNum)
            {
                case(0):
                    MidLevel--;
                break;
                case(1):
                    NorthLevel--;
                break;
                case(2):
                    SouthLevel--;
                break;
                case(3):
                    EastLevel--;
                break;
                case(4):
                    WestLevel--;
                break;
            }
        }
        for(int i = 0; i < numberOfTimes; i++)
        {
            uint[] countries = {MidLevel,NorthLevel,SouthLevel,EastLevel,WestLevel};
            int randomNum;
            
            do
            {
                if(TotalDamage == 15)
                    return false;
                
                Random.InitState((int)System.DateTime.Now.Ticks);
                randomNum = Random.Range(0, 4);
            }
            while(countries[randomNum] == 3);
            
            // needed to save countries by references but whatever
            switch(randomNum)
            {
                case(0):
                    MidLevel++;
                break;
                case(1):
                    NorthLevel++;
                break;
                case(2):
                    SouthLevel++;
                break;
                case(3):
                    EastLevel++;
                break;
                case(4):
                    WestLevel++;
                break;
            }
            
            // UnityEditor.EditorApplication.QueuePlayerLoopUpdate(); // https://forum.unity.com/threads/updating-an-image-color-in-an-editor-script.1103635/
            // Canvas.ForceUpdateCanvases(); // https://forum.unity.com/threads/unity-gui-force-repaint.442829/
            _Middle.color = Damage[MidLevel];
            _North.color = Damage[NorthLevel];
            _South.color = Damage[SouthLevel];
            _East.color = Damage[EastLevel];
            _West.color = Damage[WestLevel];
        }
        print((uint)(System.Convert.ToSingle(TotalDamage) * 6.66f));
        ConsensusManager.Instance.Revolution = (uint)(System.Convert.ToSingle(TotalDamage) * 6.66f);
        return true;
    }
    Color[] Damage = {Color.green, Color.yellow, Color.magenta, Color.red};
    // Color[] Damage = {new Color(11,212,21,255),new Color(255,255,0,255),new Color(255,166,0,255),new Color(255,25,0,255)};
    public static MapManager Instance;

    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;

        _Middle.SetAllDirty();
        _North.SetAllDirty();
        _West.SetAllDirty();
        _East.SetAllDirty();
        _South.SetAllDirty();
    }


}
