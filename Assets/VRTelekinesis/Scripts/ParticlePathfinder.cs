using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePathfinder : MonoBehaviour
{
    private List<Vector3> _positions;
    private List<bool> _checkPoints;
    private int _targetedPosition;
    private bool _moved;
    public float _speed;
    [SerializeField] private bool _activated;
    private ParticleSystem _thisParticle;
    void Start()
    {
        _thisParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {

        if (_activated)
        {
            _checkPoints = new List<bool>(new bool[_positions.Count]);

            transform.position = Vector3.MoveTowards(transform.position, _positions[_targetedPosition], _speed * Time.deltaTime);


            if (transform.position == _positions[_targetedPosition] && !_moved)
            {
                var em = _thisParticle.emission;
                em.enabled = true;
                _moved = true;
                if (_targetedPosition > 0)
                {

                    _targetedPosition -= 1;
                }
                else
                {

                    transform.position = _positions[_positions.Count - 1];
                    _targetedPosition = _positions.Count - 1;
                }
                _moved = false;
            }

        }
        else
        {
            var em = _thisParticle.emission;
            em.enabled = false;
        }

    }

    public void ActivatePath(bool b)
    {
        _activated = b;

    }


    public void SetPositions(List<Vector3> list)
    {
        if (_activated)
        {
            _positions = list;
        }
    }
}
