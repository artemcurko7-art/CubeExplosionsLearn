using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public void DecreaseScale(List<GameObject> cubes)
    {
        foreach (var cube in cubes)
            cube.transform.localScale = GetScale();
    }

    private Vector3 GetScale()
    {
        var scale = transform.localScale;

        int numberReduction = 2;

        scale.x /= numberReduction;
        scale.y /= numberReduction;
        scale.z /= numberReduction;

        return scale;
    }
}
