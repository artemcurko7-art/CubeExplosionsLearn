using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private List<GameObject> _cubes = new List<GameObject>();

    public List<GameObject> Cubes => _cubes.ToList();

    public void Spawner()
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
                GameObject cube = Instantiate(gameObject, transform.position, Quaternion.identity);
                _cubes.Add(cube);
            }
            else
            {
                Destroy(gameObject);
                break;
            }

            changedPercent /= numberReduce;
        }
    }
}
