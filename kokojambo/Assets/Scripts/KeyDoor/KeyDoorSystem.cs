using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Pathfinding.Util.RetainedGizmos;

public class KeyDoorSystem : MonoBehaviour
{
    public GameObject door;
    public GameObject keyPickup;
    public bool hasKey = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            keyPickup.SetActive(true);
            hasKey = false;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Door") && hasKey)
        {
            door.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}