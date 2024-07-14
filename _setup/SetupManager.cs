using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GamePush;

public class SetupManager : MonoBehaviour
{
    [Header("BTNs")]
    [SerializeField] Button _startBTN;
    [SerializeField] Button _leftBTN;
    [SerializeField] Button _rightBTN;
    [SerializeField] Button _buyBTN;
    [SerializeField] Button _takeBTN;
    [SerializeField] Button _clearBTN;

    [Header("TXTs")]
    [SerializeField] TextMeshProUGUI _costTXT;
    [SerializeField] TextMeshProUGUI _moneyTXT;
    [SerializeField] TextMeshProUGUI _weaponNameTXT;

    [Header("GO")]
    [SerializeField] GameObject _buyPanel;
    [SerializeField] GameObject _takePanel;

    int _wpIdToShow = 0;
    int[] _idsToPlay = new int[3];

    Gun[] _guns;
    GunSlot[] _gunSlots;

    public Action ClearSlots;

    void Start()
    {
        _startBTN.onClick.AddListener(StartDaGame);
        _leftBTN.onClick.AddListener(() => SwitchWeapon(-1));
        _rightBTN.onClick.AddListener(() => SwitchWeapon(1));
        _takeBTN.onClick.AddListener(AddTheGun);
        _clearBTN.onClick.AddListener(ClearGunSlots);

        _guns = FindObjectsOfType<Gun>();
        _gunSlots = FindObjectsOfType<GunSlot>();

        HideWeapons();

        // CheckIfIsSold();
        Invoke(nameof(CheckIfIsSold), .3f);

        ShowWeapon(_wpIdToShow);

        UpdateMoneyTXT();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Invoke(nameof(UpdateMoneyTXT), .3f);

        ShowFullScreenAd();
    }

    void ShowFullScreenAd(){
        GP_Ads.ShowFullscreen();
    }

    public void CheckIfIsSold()
    {
        foreach (var gun in _guns)
        {
            foreach (var id in GunManager.Instance.BuyedGunz)
            {
                if (gun.WpID == id)
                {
                    gun.GetComponent<SetupGun>().IsSold = true;
                }
            }
        }
    }

    void StartDaGame()
    {
        SceneSwitcher.Instance.SwitchScene(2);
    }

    void HideWeapons()
    {
        foreach (var gun in _guns)
        {
            gun.gameObject.SetActive(false);
        }
    }

    void ShowWeapon(int id)
    {
        foreach (var gun in _guns)
        {
            if (gun.WpID == id)
            {
                gun.gameObject.SetActive(true);
                _costTXT.text = gun.WpCost.ToString();
                _weaponNameTXT.text = gun.WpName;

                SetupGun setupGun = gun.GetComponent<SetupGun>();
                if (!setupGun.IsSold)
                {
                    ShowBuyPanel();
                    _buyBTN.onClick.AddListener(() => BuyTheGun(setupGun));
                }
                else
                {
                    ShowTakePanel();
                }
            }
        }
    }

    void SwitchWeapon(int multiplier)
    {
        _wpIdToShow += multiplier;

        if (_wpIdToShow > _guns.Length - 1)
        {
            _wpIdToShow = 0;
        }

        if (_wpIdToShow < 0)
        {
            _wpIdToShow = _guns.Length - 1;
        }

        HideWeapons();
        ShowWeapon(_wpIdToShow);
    }

    void AddTheGun()
    {
        foreach (var gunSlot in _gunSlots)
        {
            if (gunSlot.IsEmpty)
            {
                gunSlot.SetTheGun(_wpIdToShow);
                _idsToPlay[gunSlot.Id] = _wpIdToShow;
                SceneSwitcher.Instance.SetTheGoonz(_idsToPlay);
                break;
            }
        }
    }

    void ClearGunSlots()
    {
        ClearSlots?.Invoke();
    }

    void BuyTheGun(SetupGun gun)
    {
        if (MoneyManager.Instance.TotalMoney >= gun.GetComponent<Gun>().WpCost)
        {
            if (gun.gameObject.activeSelf)
            {
                gun.IsSold = true;
                GunManager.Instance.SetTheInventory(gun.GetComponent<Gun>().WpID);
                MoneyManager.Instance.TotalMoney -= gun.GetComponent<Gun>().WpCost;
                UpdateMoneyTXT();
                ShowTakePanel();
            }

        }

    }

    public void UpdateMoneyTXT()
    {
        _moneyTXT.text = MoneyManager.Instance.TotalMoney.ToString();
    }

    void ShowTakePanel()
    {
        _takePanel.SetActive(true);
        _buyPanel.SetActive(false);
    }

    void ShowBuyPanel()
    {
        _takePanel.SetActive(false);
        _buyPanel.SetActive(true);
    }
}
