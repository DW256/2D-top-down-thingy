using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine player;
    [SerializeField] private Image healthImageFill;

    void Update()
    {
        healthImageFill.fillAmount = (float)player.Health.health / (float)player.Health.MaxHealth;
    }
}
