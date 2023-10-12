using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float _speed = 70f;
    public GameObject _impactEffectPrefab;

    public void Seek(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
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
    }

    void HitTarget()
    {
        GameObject effectGO = (GameObject)Instantiate(_impactEffectPrefab, transform.position, transform.rotation);
        Destroy(effectGO, 2f);

        Destroy(_target.gameObject);
        Destroy(gameObject);
    }
}
