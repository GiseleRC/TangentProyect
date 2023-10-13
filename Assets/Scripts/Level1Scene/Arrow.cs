using UnityEngine;

public class Arrow : MonoBehaviour, IPooleableObject
{
    [SerializeField] private float _speed = 70f;
    [SerializeField] private GameObject _impactEffectPrefab;

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
        float distanceThisFrame = _speed * Time.deltaTime;

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

        Destroy(_target.gameObject);
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