using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D picture;
    public ColorMapping[] mappings;

    public float offset = 5;

    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        for(int x=0; x<picture.width; x++)
        {
            for(int y=0; y<picture.height; y++)
            {
                SpawnTile(x, y);
            }
        }
    }

    public void SpawnTile(int x, int z)
    {
        Color pixel = picture.GetPixel(x, z);
        foreach(ColorMapping m in mappings)
        {
            if(pixel.Equals(m.color))
            {
                Vector3 pos = new Vector3(x, 0, z) * offset;
                Instantiate(m.prefab,pos, Quaternion.identity, transform);
            }
        }

    }
}
