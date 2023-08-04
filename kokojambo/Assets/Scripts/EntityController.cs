using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour , IDamageReciever
{
    public float hp { get; set; }
    private Animator _animator;
    [SerializeField]private GameObject _deadPrefab;
    [SerializeField]private LayerMask _damageDealers;
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }
    public void Die()
    {
        _animator.Play("die");
        Destroy();
    }
    IEnumerable Destroy()
    {   

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        Instantiate(_deadPrefab, transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public bool IsInLayerMask(int layer, LayerMask layermask) { return layermask == (layermask | (1 << layer)); }
}
