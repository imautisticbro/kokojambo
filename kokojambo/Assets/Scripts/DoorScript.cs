using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject _key;
    [SerializeField] private string _sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SwitchScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_key == null &&collision.gameObject.layer == LayerMask.NameToLayer("Player")) SwitchScene(_sceneName);
    }
}
