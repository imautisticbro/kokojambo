using System.Collections;
using UnityEngine;

public class HookThrower : MonoBehaviour
{
    [SerializeField] private GameObject hookPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float throwForce = 100f;
    [SerializeField] private float maxDistance = 10f;

    [SerializeField] private KeyCode _throwKey = KeyCode.R;
    private bool hasHookAttached = false;
    private GameObject _thrownHook;

    void Update()
    {
        hasHookAttached = _thrownHook == null ? false : hasHookAttached;
        if (Input.GetKeyDown(_throwKey) && !hasHookAttached)
        {
            ThrowHook();
        }
        else if (Input.GetKeyDown(_throwKey) && hasHookAttached )
        {
            Destroy(_thrownHook);
            hasHookAttached = false;
        }
        if(_thrownHook!=null && Vector3.Distance(player.transform.position, _thrownHook.transform.position) >= maxDistance)
        {
            Destroy(_thrownHook);
            hasHookAttached = false;
        }
    }

    void ThrowHook()
    {
        _thrownHook = Instantiate(hookPrefab, transform.position, Quaternion.identity);
        Rigidbody2D hookRigidbody = _thrownHook.GetComponent<Rigidbody2D>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 throwDirection = (mousePosition - transform.position).normalized;
        hookRigidbody.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);

        hasHookAttached = true;
    }
}