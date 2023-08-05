using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour , IDamageReciever
{
    public float hp;
    private Animator _animator;
    [SerializeField]private GameObject _deadPrefab;
    [SerializeField]private LayerMask _damageDealers;
    [SerializeField] private List<Material> materials = new();
    [SerializeField] private float _materialSwapTime;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        StartCoroutine(MaterialSwap());
        if (hp <= 0) Die();
    }
    public void Die()
    {
        _animator.Play("death");
        Destroy(gameObject);
    }

    IEnumerator MaterialSwap()
    {
        _spriteRenderer.material = materials.ToArray()[1];
        yield return new WaitForSeconds(_materialSwapTime);
        _spriteRenderer.material = materials.ToArray()[2];
        yield return new WaitForSeconds(_materialSwapTime);
        _spriteRenderer.material = materials.ToArray()[0];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public bool IsInLayerMask(int layer, LayerMask layermask) { return layermask == (layermask | (1 << layer)); }
}
