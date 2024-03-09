using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity, IGunEntity
{
    [field: SerializeField]
    public Camera Camera { get; private set; }

    [field: SerializeField]
    public GameUI GameUI { get; private set; }

    [field: SerializeField]
    public Gun Gun { get; private set; }

    [field: SerializeField, Header("Dash")]
    public float DashSpeed { get; private set; }

    [field: SerializeField]
    public float DashTime { get; private set; }

    [field: SerializeField]
    public float DashCooldown { get; private set; }
    public bool IsDashing { get; private set; } = false;

    public override bool IsPlayer => true;

    private float _dashCooldownTimer = 0.0f;

    // Player.cs
    public List<PowerUp> ActivePowerUps { get; private set; } = new();

    public List<Key> Keys { get; private set; } = new();

    private Quaternion _aimDirection = Quaternion.identity;

    private void Update()
    {
        CheckInput();
    }

    protected override void EntityDied()
    {
        StatisticsManager.DeathStatistic.AddValue(1);
        GameUI.GameOverScreen.gameObject.SetActive(true);
    }

    private void CheckInput()
    {
        // Aim Gun
        AimGun();

        // Dash
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDash();
        }

        // Move Player
        if (TakingKnockback)
        {
            DoTakeKnockback();
        }
        else
        {
            if (IsDashing)
            {
                DoDash();
            }
            else
            {
                Move();
            }
        }

        Rb.velocity = _moveDirection * ActiveMoveSpeed;
    }

    public void AimGun()
    {
        // Get Input
        Vector2 mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);

        // Calculate Angle
        Vector2 direction = mousePosition - new Vector2(Gun.Pivot.position.x, Gun.Pivot.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _aimDirection = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));

        // Aim Gun
        Gun.Aim(_aimDirection);
    }

    private void StartDash()
    {
        // Allow the Player to Dash in a Dash sounds cool
        // So instead of a return; I just reset the Dash
        if (IsDashing)
            EndDash();

        IsDashing = true;

        ActiveMoveSpeed = DashSpeed;

        // Set MoveDirection
        _moveDirection = new Vector2(
            Mathf.Cos(_aimDirection.eulerAngles.z * Mathf.Deg2Rad),
            Mathf.Sin(_aimDirection.eulerAngles.z * Mathf.Deg2Rad)
            ).normalized;
    }
    private void DoDash()
    {
        _dashCooldownTimer += Time.deltaTime;

        // Check for End of Dash
        if (_dashCooldownTimer >= DashTime)
        {
            EndDash();
            return;
        }
    }
    private void EndDash()
    {
        IsDashing = false;
        ActiveMoveSpeed = Speed;
        _dashCooldownTimer = 0.0f;
    }

    private void Move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(xInput, yInput).normalized;
        ActiveMoveSpeed = Speed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>Null if none, PowerUp if it has</returns>
    private PowerUp HasPowerUp(string name)
    {
        for (int i = 0; i < ActivePowerUps.Count; i++)
        {
            if (ActivePowerUps[i].Name == name)
            {
                return ActivePowerUps[i];
            }
        }

        return null;
    }

    private void AddPowerUp(PowerUp powerUp)
    {
        // Check if PowerUp already exists
        PowerUp existingPowerUp = HasPowerUp(powerUp.Name);

        if (existingPowerUp == null)
        {
            ActivePowerUps.Add(powerUp);
            GameUI.AddPowerUp(powerUp);
        }
        else
        {
            // TODO: logic that updates the time or something
        }
    }

    private void RemovePowerUp(PowerUp powerUp)
    {
        for (int i = 0; i < ActivePowerUps.Count; i++)
        {
            if (ActivePowerUps[i].Name == powerUp.Name)
            {
                ActivePowerUps.RemoveAt(i);
                GameUI.RemovePowerUp(powerUp.Name);
                return;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Spike"))
        {
            Damage(10.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Item item))
        {
            PickupItem(item);
            return;
        }

        if (collision.CompareTag("KeyDoor"))
        {
            if (!collision.TryGetComponent(out KeyDoor door))
            {
                return;
            }

            door.TryOpen(this);
        }
    }

    private void PickupItem(Item item)
    {
        switch (item.ItemTag)
        {
            case "PowerUp":
                PowerUp powerUp = item.GetComponent<PowerUpPickupable>().ToPowerUp();
                AddPowerUp(powerUp);
                break;

            case "Key":
                Keys.Add(item.GetComponent<KeyItem>().ToKey());
                break;
        }

        item.PickedUp();
    }
}
