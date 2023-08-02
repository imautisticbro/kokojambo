using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesDeath : MonoBehaviour

{
    public MovementController2D movementController; // ������ �� ������ ���������� ���������
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
        movementController.enabled = false; // ��������� ���������� ���������
        gameObject.SetActive(false); // ��������� ����������� ���������
        // ��� ����� ����� �������� ������ ������, ���� �����.
    }
}
