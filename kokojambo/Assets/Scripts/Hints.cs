using UnityEngine;
using TMPro;

public class Hints: MonoBehaviour
{
    public GameObject coin; 
    public TextMeshProUGUI hintText; 
    public float destroyDelay = 3f;
    private bool isDestroyed = false;

    private void Update()
    {
        
        if (coin == null && !isDestroyed)
        {
           
            hintText.text = "�������� ������ ���� �� ��������� ������ � ����������� ������� R ����� ������� ����� � ������������ ����� ����.";

            
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
