using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    [SerializeField]private GameObject _target;
    [SerializeField]private float _radius;
    [SerializeField]private float _disposePeriod;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float timeBuffer;
    // Update is called once per frame
    void Update()
    {
        timeBuffer += Time.deltaTime;
        if (timeBuffer >= _disposePeriod)
        {
            timeBuffer = 0;
            Dispose(_radius);
        }
    }

    private void Dispose(float radius)
    {
        _target.transform.position = Random.insideUnitCircle * radius;
    }
}
