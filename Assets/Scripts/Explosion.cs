using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _minRangeExplodeForce;
    [SerializeField] private int _maxRangeExplodeForce;
    [SerializeField] private int _minRangeExplodeRadius;
    [SerializeField] private int _maxRangeExplodeRadius;

    public void Explode(List<Cube> cubes)
    {
        foreach (var cube in cubes)
        {
            int explodeForce = Random.Range(_minRangeExplodeForce, _maxRangeExplodeForce + 1);
            int explodeRadius = Random.Range(_minRangeExplodeRadius, _maxRangeExplodeRadius + 1);
            cube.Rigidbody.AddExplosionForce(explodeForce, cube.transform.position, explodeRadius);
        }
    }
}
