using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private int _minRangeExplodeForce = 100;
    private int _maxRangeExplodeForce = 200;
    private int _minRangeExplodeRadius = 10;
    private int _maxRangeExplodeRadius = 20;

    public void Explosion()
    {
        foreach (var cube in GetExplodableObjects())
            cube.AddExplosionForce(Random.Range(_minRangeExplodeForce, _maxRangeExplodeForce), transform.position, Random.Range(_minRangeExplodeRadius, _maxRangeExplodeRadius));
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> cubes = new List<Rigidbody>();

        Collider[] hits = Physics.OverlapSphere(transform.position, Random.Range(_minRangeExplodeRadius, _maxRangeExplodeRadius));

        foreach (var hit in hits)
            if (hit.attachedRigidbody != null && hit.gameObject != gameObject)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
