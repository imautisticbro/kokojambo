using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamageReciever
{
    public float hp { get; set; }
    public List<Transform> savedDivers = new();
    private Animator _animator;
    [SerializeField] private GameObject _deadPrefab;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private LayerMask _damageDealers;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (gameObject.transform.position.y <= -10) Die();
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }
    public void Die()
    {

        if(savedDivers.Count!=0)
        {
            Instantiate(_deadPrefab, transform.position, Quaternion.identity);
            Transform diver = savedDivers.ToArray()[0];
            gameObject.transform.position = diver.position;
            savedDivers.Remove(diver);
            Destroy(diver.gameObject);
            return;
        }
        _animator.Play("death");
        StartCoroutine(Destroy());

    }
    IEnumerator Destroy()
    {


        yield return new WaitForSeconds(1f);
        Instantiate(_deadPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsInLayerMask(collision.collider.gameObject.layer, _damageDealers)) Die();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInLayerMask(collision.gameObject.layer, _damageDealers)) Die();
    }
    public bool IsInLayerMask(int layer, LayerMask layermask) { return layermask == (layermask | (1 << layer)); }
}
