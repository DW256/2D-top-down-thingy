using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static float Timer = 0f;

    [SerializeField] private PlayerStateMachine player;
    [SerializeField] private Image healthImageFill;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private Image cdImageFill;
    [SerializeField] private TextMeshProUGUI TimerText;

    private void Start()
    {
        Timer = 0f;
    }

    void FixedUpdate()
    {
        ProcessHealthBar();
        ProcessCDBar();
        ProcessTimer();
    }

    void ProcessHealthBar()
    {
        int current = player.Health.health;
        int max = player.Health.MaxHealth;
        healthImageFill.fillAmount = (float)current / (float)max;
        HealthText.text = $"{current}/{max}";
    }

    void ProcessCDBar()
    {
        cdImageFill.fillAmount = player.Gun.GetCoolDownPercentage();
    }

    void ProcessTimer()
    {
        if (GameManager.Instance.isPaused) return;
        Timer += Time.fixedDeltaTime;

        TimerText.text = Timer.ToString("0");
    }
}
