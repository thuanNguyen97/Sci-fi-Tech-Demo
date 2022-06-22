using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Text _reloadText;
    [SerializeField]
    private Text _pickUpText;
    [SerializeField]
    private Text _buyText;

    [SerializeField]
    private GameObject _coin;

    public void Start()
    {
        _pickUpText.enabled = false;
        _buyText.enabled = false;
    }

    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo: " + count;
    }

    public void CollectedCoin()
    {
        _coin.SetActive(true);
    }

    public void RemoveCoin()
    {
        _coin.SetActive(false);
    }

    public void reloadTextDisable()
    {
        _reloadText.enabled = false; //turn off reload text
    }

    public void reloadTextEnable()
    {
        _reloadText.enabled = true; //turn on reload text
    }

    public void pickupTextDisable()
    {
        _pickUpText.enabled = false;
    }

    public void pickUpTextEnable()
    {
        _pickUpText.enabled = true;
    }

    public void buyTextDisable()
    {
        _buyText.enabled = false;
    }

    public void buyTextEnable()
    {
        _buyText.enabled = true;
    }
}
