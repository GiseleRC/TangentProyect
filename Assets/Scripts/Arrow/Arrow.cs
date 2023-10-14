using UnityEngine;

public class Arrow : MonoBehaviour, IPooleableObject
{
    [SerializeField] private GameObject _impactEffectPrefab;
    [SerializeField] private ArrowStats _stats;

    private Transform _target = null;

    public void Seek(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        if(_target == null)
        {
            ArrowFactory.Instance.ReturnObjectToPool(this);
            return;
        }

        Vector3 dir = _target.position - transform.position;
        float distanceThisFrame = _stats.Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    void HitTarget()
    {
        GameObject effectGO = (GameObject)Instantiate(_impactEffectPrefab, transform.position, transform.rotation);
        Destroy(effectGO, 2f);

        Enemy enemy = _target.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Die();
        }

        ArrowFactory.Instance.ReturnObjectToPool(this);
    }

    public void Reset()
    {
        _target = null;
    }

    public static void TurnOn(Arrow arrow)
    {
        arrow.gameObject.SetActive(true);
    }

    public static void TurnOff(Arrow arrow)
    {
        arrow.gameObject.SetActive(false);
    }
}