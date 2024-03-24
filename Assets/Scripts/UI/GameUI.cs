using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [field: SerializeField]
    private Transform EscapeMenu { get; set; }
    public static bool EscapeOpen { get; set; } = false;

    [field: SerializeField, Header("PowerUps")]
    private Transform PowerUpsParent { get; set; }

    [field: SerializeField]
    private GameObject PowerUpUIPrefab { get; set; }

    [field: SerializeField]
    public Transform GameOverScreen { get; private set; }

    [field: SerializeField]
    public Transform NextLevelScreen { get; private set; }

    [field: SerializeField]
    private PlayerController Player { get; set; }

    [field: SerializeField]
    private TextMeshProUGUI PlayerHealthText { get; set; }

    [field: SerializeField]
    private TextMeshProUGUI PlayerKeysText { get; set; }

    private void Awake()
    {
        Player.HealthChangedEvent += HealthChanged;
        Player.KeysChangedEvent += KeysChanged;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleEscapeMenu();
        }

        if (GameOverScreen.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                GameOverScreen.gameObject.SetActive(false);
                GameManager.Instance.SelectMainMenu();
            }
        }

        if (NextLevelScreen.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                NextLevelScreen.gameObject.SetActive(false);
                GameManager.Instance.SelectMainMenu();
            }
        }
    }

    #region EscapeMenu
    public void ExitLevelButton()
    {
        CloseEscapeMenu();

        StatisticsManager.Instance.SaveStatisticsToSave();
        GameManager.Instance.SelectMainMenu();
    }

    public void OpenEscapeMenu()
    {
        SetEscapeMenuOpen(true);
    }

    public void CloseEscapeMenu()
    {
        SetEscapeMenuOpen(false);
    }

    public void ToggleEscapeMenu()
    {
        SetEscapeMenuOpen(!EscapeOpen);
    }

    public void HealthChanged(float newHealth)
    {
        PlayerHealthText.text = "Health: " + newHealth;
    }

    public void KeysChanged(int newKeyAmount)
    {
        PlayerKeysText.text = "Keys: " + newKeyAmount;
    }

    private void SetEscapeMenuOpen(bool open)
    {
        EscapeMenu.gameObject.SetActive(open);
        EscapeOpen = open;

        if (EscapeOpen)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
    #endregion EscapeMenu

    #region PowerUps
    public void AddPowerUp(PowerUp powerUp)
    {
        GameObject powerUpUI = Instantiate(PowerUpUIPrefab, PowerUpsParent);
        powerUpUI.GetComponent<PowerUpUI>().UpdatePowerUp(powerUp);
        powerUp.OnExpired += () => { RemovePowerUp(powerUp.Name); };
    }

    public void RemovePowerUp(string name)
    {
        for (int i = 0; i < PowerUpsParent.childCount; i++)
        {
            if (PowerUpsParent.GetChild(i).GetComponent<PowerUpUI>().PowerUp.Name == name)
            {
                Destroy(PowerUpsParent.GetChild(i).gameObject);
            }
        }
    }
    #endregion PowerUps
}
