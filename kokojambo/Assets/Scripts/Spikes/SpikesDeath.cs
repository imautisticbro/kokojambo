using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDeath : MonoBehaviour

{
    public MovementController2D movementController; // Ссылка на скрипт управления движением
    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes") && !isDead)
        {
            KillCharacter();
        }
    }

    private void KillCharacter()
    {
        isDead = true;
        movementController.enabled = false; // Отключаем управление движением
        gameObject.SetActive(false); // Отключаем отображение персонажа
        // Тут также можно добавить другую логику, если нужно.
    }
}
