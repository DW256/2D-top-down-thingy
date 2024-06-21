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
    [SerializeField] private Image cdImageFill;
    [SerializeField] private TextMeshProUGUI TimerUI;

    void FixedUpdate()
    {
        ProcessHealthBar();
        ProcessCDBar();
        ProcessTimer();
    }

    void ProcessHealthBar()
    {
        healthImageFill.fillAmount = (float)player.Health.health / (float)player.Health.MaxHealth;
    }

    void ProcessCDBar()
    {
        cdImageFill.fillAmount = player.Gun.GetCoolDownPercentage();
    }

    void ProcessTimer()
    {
        if (PauseController.isPaused) return;
        Timer += Time.fixedDeltaTime;

        TimerUI.text = Timer.ToString("0");
    }
}
