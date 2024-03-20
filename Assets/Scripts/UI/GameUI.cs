using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [field: SerializeField]
    public Transform EscapeMenu { get; private set; }
    public static bool EscapeOpen { get; set; } = false;

    [field: SerializeField, Header("PowerUps")]
    public Transform PowerUpsParent { get; private set; }

    [field: SerializeField]
    public GameObject PowerUpUIPrefab { get; private set; }

    [field: SerializeField]
    public Transform GameOverScreen { get; private set; }

    [field: SerializeField]
    public Transform NextLevelScreen { get; private set; }

    [field: SerializeField]
    public PlayerController Player { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI PlayerHealthText { get; private set; }

    private void Awake()
    {
        Player.HealthChangedEvent += HealthChanged;
    }

    void Update()
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
                // TODO: reset scene?
                GameManager.Instance.SelectMainMenu();
            }
        }

        if (NextLevelScreen.gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                NextLevelScreen.gameObject.SetActive(false);
                // TODO: go to next lvel
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
    }

    public void RemovePowerUp(string name)
    {

    }
    #endregion PowerUps
}
