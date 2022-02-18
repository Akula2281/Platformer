using System.Collections;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{

    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;

    [SerializeField] private float _speed;

    private Transform _target;

    private void Awake()
    {
        _target = _firstPoint;

        var scale = transform.localScale;

        if (transform.position.x - _target.position.x < 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = -Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if ((_target.position - transform.position).magnitude <= 0.1f)
        {
            var firstPoint = _target == _firstPoint;

            _target = firstPoint ? _secondPoint : _firstPoint;

            var scale = transform.localScale;

            if(transform.position.x - _target.position.x < 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            else
            {
                scale.x = -Mathf.Abs(scale.x);
            }

            transform.localScale = scale;
        }
    }
}