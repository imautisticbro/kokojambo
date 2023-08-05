using UnityEngine;
using TMPro;

public class Hint2 : MonoBehaviour
{
    public GameObject coin;
    public TextMeshProUGUI hintText;
    public float destroyDelay = 3f;
    private bool isDestroyed = false;

    private void Update()
    {

        if (coin == null && !isDestroyed)
        {

            hintText.text = "¬стречайте новых друзей на своем пути! ѕодходите к ним и присоедин€йте к себе, чтобы в случае смерти у вас была дополнительна€ жизнь.";


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
