using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using TMPro;

public class ConsensusManager : MonoBehaviour
{
    private long _WarFund;
    [SerializeField] TMP_Text WarText;

    public long WarFund
    {
        
        get{return _WarFund;}
        set
        {
            _WarFund = value;
            WarText.text = $"{value.ToString("C", CultureInfo.CreateSpecificCulture("en-us"))}";
        }
    }

    private int _Tax;
    [SerializeField] TMP_Text TaxText;

    public int Tax
    {
        get{return _Tax;}
        set
        {
            _Tax = value;
            TaxText.text = $"{value.ToString()}%";
        }
    }

    private long _Welfare;
    [SerializeField] TMP_Text WelfareText;

    public long Welfare
    {
        get{return _Welfare;}
        set
        {
            _Welfare = value;
            WelfareText.text = $"{value.ToString("C", CultureInfo.CreateSpecificCulture("en-us"))}";
        }
    }

    private long _CentralBank;
    [SerializeField] TMP_Text CentralBankText;

    public long CentralBank
    {
        get{return _CentralBank;}
        set
        {
            _CentralBank = value;
            CentralBankText.text = $"{value.ToString("C", CultureInfo.CreateSpecificCulture("en-us"))}";
        }
    }

    private long _ReElectionFund;
    [SerializeField] TMP_Text ReElectionFundText;

    public long ReElectionFund
    {
        get{return _ReElectionFund;}
        set
        {
            _ReElectionFund = value;
            ReElectionFundText.text = $"{value.ToString("C", CultureInfo.CreateSpecificCulture("en-us"))}";
        }
    }

    private uint _Revolution;
    [SerializeField] Image RevolutionImage;
    public uint Revolution
    {
        get{return _Revolution;}
        set
        {
            _Revolution = value;
            if(value <= 1)
                RevolutionImage.fillAmount = (float)value/100f;    
        }
    }

    public static ConsensusManager Instance;

    void Awake()
    {
        if(Instance)
            Destroy(this);
        else
            Instance = this;
    }

    void Start()
    {
        WarFund = 1000000000;
        Tax = 15;
        Welfare = 1000000;
        CentralBank = 20000000000;
        ReElectionFund = 0;
        Revolution = 0;
    }
}
