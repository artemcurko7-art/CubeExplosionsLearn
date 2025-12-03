using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Spawn _spawn;
    [SerializeField] private Scale _scale;
    [SerializeField] private Colored _colorChange;
    [SerializeField] private Explode _explode;

    public void ProcessObject()
    {
        _spawn.Spawner();
        _scale.DecreaseScale(_spawn.Cubes);
        _colorChange.ApplyColor(_spawn.Cubes);
        _explode.Explosion();
    }   
}
