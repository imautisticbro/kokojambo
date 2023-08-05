using UnityEngine;
using TMPro;

public class Hint5 : MonoBehaviour
{
    public GameObject coin;
    public TextMeshProUGUI hintText;
    public float destroyDelay = 3f;
    private bool isDestroyed = false;

    private void Update()
    {

        if (coin == null && !isDestroyed)
        {

            hintText.text = "Приготовьтесь к файту с боссом, будьте осторожны, ведь он создает свои маленькие копии!";


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

