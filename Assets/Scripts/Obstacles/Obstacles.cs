using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacles : MonoBehaviour
{
    [SerializeField] protected float _coolDown;

    public virtual void Activate() { }

    public abstract IEnumerator StateChange();

    /*public void TakeDamage(GameObject player)
    {
        Debug.Log("se intenta aplicar da�o");
        player.TryGetComponent<PlayerController>(out var playerC);

        playerC.transform.position = playerC.lastCheckPoint;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerC.currentLifes--;
        AudioManager.Instance.PlaySFX("Die");
        if (playerC.currentLifes <= 0) playerC.Death();
    }*/
}
