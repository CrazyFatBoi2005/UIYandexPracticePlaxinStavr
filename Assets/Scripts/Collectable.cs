using UnityEngine;
using Random = UnityEngine.Random;

public class Collectable : MonoBehaviour
{
    [HideInInspector] public Resources _resourcesForCollectable;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private float _throwFroce;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Renderer _renderer;

    private void OnEnable()
    {
        RandomThrow();
    }

    private void RandomThrow()
    {
        Vector2 _randomDirection = new Vector2(Random.Range(-1f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        var direction = new Vector3(_randomDirection.x, 1, _randomDirection.y).normalized;
        _rigidbody.AddForce(direction * _throwFroce, ForceMode.Impulse);
    }

    public void Collect()
    {
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(1);
        _resourcesForCollectable.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }

    public void ChangeConstants(Resources currentResources)
    {
        _resourcesForCollectable = currentResources;
    }
}
