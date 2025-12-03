using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private GameObject _cube;

    private int _minRangeExplodeForce = 100;
    private int _maxRangeExplodeForce = 200;
    private int _minRangeExplodeRadius = 10;
    private int _maxRangeExplodeRadius = 20;

    public void ProcessObject()
    {
        Spawner();
        DecreaseScale();
        ApplyColor();
        Explode();
    }
    
    private void Spawner()
    {
        int minRange = 2;
        int maxRange = 6;

        int percent = 100;
        int numberReduce = 2;
        int changedPercent = percent;

        int amountCubes = Random.Range(minRange, maxRange + 1);

        for (int i = 0; i < amountCubes; i++)
        {
            int currentPercent = Random.Range(0, percent + 1);

            if (currentPercent <= changedPercent)
            {
                _cube = Instantiate(gameObject, transform.position, Quaternion.identity);
            }
            else
            {
                Destroy(gameObject);
                break;
            }

            changedPercent /= numberReduce;
        }
    }

    private void Explode()
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

    private void DecreaseScale() =>
        _cube.transform.localScale = GetScale();

    private Vector3 GetScale()
    {
        var scale = transform.localScale;

        int numberReduction = 2;

        scale.x /= numberReduction;
        scale.y /= numberReduction;
        scale.z /= numberReduction;

        return scale;
    }

    private void ApplyColor() =>
        _cube.GetComponent<MeshRenderer>().material.color = GetColor();

    private Color GetColor()
    {
        Color color = Random.ColorHSV();

        return color;
    }
}
