using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float _speed = 70f;
    public GameObject _impactEffectPrefab;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
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

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
