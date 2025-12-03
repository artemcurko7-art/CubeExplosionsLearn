using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Colored : MonoBehaviour
{
    public void ApplyColor(List<GameObject> cubes)
    {
        foreach (var cube in cubes)
            cube.GetComponent<MeshRenderer>().material.color = GetColor();
    }

    private Color GetColor()
    {
        Color color = Random.ColorHSV();

        return color;
    }
}
