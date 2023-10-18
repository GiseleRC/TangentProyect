using System.Collections;
using UnityEngine;

public class Arrow : MonoBehaviour, IPooleableObject
{
    [SerializeField] private ParticleSystem _impactFXPrefab;
    [SerializeField] private ArrowStats _stats;

    private Renderer _renderer = null;
    private Transform _target = null;
    private ParticleSystem _impactFXGO = null;

    public void Seek(Transform target)
    {
        _target = target;
    }

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _impactFXGO = (ParticleSystem)Instantiate(_impactFXPrefab, transform);
        _impactFXGO.Stop();
    }

    void Update()
    {
        if (_impactFXGO.isPlaying) return;

        if(_target == null)
        {
            ArrowFactory.Instance.ReturnObjectToPool(this);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = _stats.Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget(_stats.Damage);
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    void HitTarget(int damageArrow)
    {
        Enemy enemy = _target.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damageArrow);
        }

        StartCoroutine(ImpactAndDestroy());
    }

    IEnumerator ImpactAndDestroy()
    {
        _renderer.enabled = false;
        _impactFXGO.Play();
        while (_impactFXGO.isPlaying) yield return null;

        ArrowFactory.Instance.ReturnObjectToPool(this);
    }

    public void Reset()
    {
        _renderer.enabled = true;
        _target = null;
        _impactFXGO.Clear();
    }

    public static void TurnOn(Arrow arrow)
    {
        arrow.gameObject.SetActive(true);
        arrow._impactFXGO.Stop();
    }

    public static void TurnOff(Arrow arrow)
    {
        arrow.gameObject.SetActive(false);
        arrow._impactFXGO.Stop();
    }
}