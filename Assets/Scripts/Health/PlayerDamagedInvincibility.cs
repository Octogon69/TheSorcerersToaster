using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float _invincibilityDuration;
    private InvincibiliyController _InvincibilityController;


    private void Awake()
    {
        _InvincibilityController = GetComponent<InvincibiliyController>();
    }
    public void StartInvincibility()
    {
        _InvincibilityController.StartInvincibility(_invincibilityDuration);
    }
}
