using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookTip : MonoBehaviour
{
    [SerializeField] private GameObject _rope;
    private Rigidbody2D _rigidbody2D;
    private GameObject _ropeInstance;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Default"))//magic bruh
        {
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
            _ropeInstance = Instantiate(_rope, transform);
            //_ropeInstance.transform.position = Vector3.zero;
        }
    }
}
