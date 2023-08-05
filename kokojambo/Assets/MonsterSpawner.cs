using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnPeriod;
    [SerializeField] private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private float _bufferTime;
    void Update()
    {
        _bufferTime += Time.deltaTime;
        if(_bufferTime>=_spawnPeriod)
        {
            _bufferTime = 0;
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity).GetComponent<AIDestinationSetter>().target = _playerTransform;
        }
    }
}
