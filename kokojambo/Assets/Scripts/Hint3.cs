using UnityEngine;
using TMPro;

public class Hint3 : MonoBehaviour
{
    public GameObject coin;
    public TextMeshProUGUI hintText;
    public float destroyDelay = 3f;
    private bool isDestroyed = false;

    private void Update()
    {

        if (coin == null && !isDestroyed)
        {

            hintText.text = "»щите ключи чтобы открывать двери и переходить на следующий уровень!";


            Invoke("ResetHintText", destroyDelay);
            isDestroyed = true;
        }
    }

    private void ResetHintText()
    {

        hintText.text = "";


        Destroy(gameObject);
    }
}

