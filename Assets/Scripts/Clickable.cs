using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{

    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private GameObject _collectablePrefab;
    [SerializeField] private Resources _resources;

    [SerializeField] private MaterialManager _materialManager;

    private int _coinsPerClick = 1;
    private Vector3 _spawnOffset = new Vector3(0, 0.5f, 0);

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        // Спавним _coinsPerClick форм Collectable
        CollectapbleSpawner(_coinsPerClick);
        StartCoroutine(HitAnimation());
    }

    private void CollectapbleSpawner(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var _newCollectable = Instantiate(_collectablePrefab, transform.position + _spawnOffset, Random.rotation);
            _newCollectable.GetComponent<Renderer>().material = _materialManager.currentMaterial;
            _newCollectable.GetComponent<Collectable>().ChangeConstants(_resources);
        }
    }

    // Анимация колебания куба
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    // Этот метод увеличивает количество монет, получаемой при клике
    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }

}
