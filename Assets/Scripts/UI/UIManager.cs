using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [field: SerializeField, Header("PowerUp")]
    public Transform PowerUpParent { get; private set; }

    [field: SerializeField]
    public GameObject PowerUpUIPrefab { get; private set; }

    public void AddPowerUp(PowerUp powerUp)
    {
        GameObject powerUpUI = Instantiate(PowerUpUIPrefab, PowerUpParent);
        powerUpUI.GetComponent<PowerUpUI>().UpdatePowerUp(powerUp);
    }

    public void RemovePowerUp(string name)
    {

    }
}
