using System.Collections;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    //List<PowerUp> powerUpsList = new List<PowerUp>();
    PowerUp _currentPowerUp;
    PowerUp _nextPowerUp;

    [SerializeField] string _currentPU;
    [SerializeField] string _nextPU;

    public PowerUpState puState;

    public void ObtainPowerUp(PowerUp pickedPU)
    {
        /*if (currentPowerUp == null) currentPowerUp = pickedPU;
        else if (powerUpsList.Count > 0)
        {
            currentPowerUp = powerUpsList[0];
            powerUpsList.RemoveAt(0);
            powerUpsList.Add(pickedPU);
        }
        else powerUpsList.Add(pickedPU);
        */

        if (_currentPowerUp == null) _currentPowerUp = pickedPU;
        else if (_nextPowerUp != null)
        {
            _currentPowerUp = _nextPowerUp;
            _nextPowerUp = pickedPU;
        }
        else _nextPowerUp = pickedPU;

        UpdatePowerUpStrings();
        puState = PowerUpState.Ready;
    }

    public void TryUsePowerUp(PlayerController player)
    {
        if (_currentPowerUp == null) return;

        switch (puState)
        {
            case PowerUpState.Ready:
                if (_currentPowerUp.CanUse()) UsePowerUp(player);
                break;

            case PowerUpState.Locked:
                TryEquipNextPowerUp();
                break;
        }
    }

    void UsePowerUp(PlayerController player)
    {
        puState = PowerUpState.Locked;
        _currentPowerUp.StartAction(player);
        StartCoroutine(TimerFinishAction(_currentPowerUp.activeTime, player));
    }

    void TryEquipNextPowerUp()
    {
        /*if (powerUpsList.Count == 0) return;
        currentPowerUp = powerUpsList[0];
        powerUpsList.RemoveAt(0);*/

        if (_nextPowerUp == null)
        {
            _currentPowerUp = null;
            _currentPU = null;
            return;
        }
        _currentPowerUp = _nextPowerUp;
        _nextPowerUp = null;
        UpdatePowerUpStrings();
        puState = PowerUpState.Ready;
    }

    IEnumerator TimerFinishAction(float _activeTime, PlayerController player)
    {
        Debug.Log("el tiempo activo es de: " + _activeTime);
        yield return new WaitForSeconds(_activeTime);
        _currentPowerUp.FinishAction(player);
        TryEquipNextPowerUp();
    }

    void UpdatePowerUpStrings()
    {
        _currentPU = _currentPowerUp?.ToString();
        _nextPU = _nextPowerUp?.ToString();
    }
}

public enum PowerUpState
{
    Ready,
    Locked
}