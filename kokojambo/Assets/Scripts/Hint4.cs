using UnityEngine;
using TMPro;

public class Hint4 : MonoBehaviour
{
    public GameObject coin;
    public TextMeshProUGUI hintText;
    public float destroyDelay = 3f;
    private bool isDestroyed = false;

    private void Update()
    {

        if (coin == null && !isDestroyed)
        {

            hintText.text = "Будьте осторожны! На уровнях есть монстры, используйте R и курсор мыши чтобы стрелять в них";


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

