using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D picture;
    public ColorMapping[] mappings;

    public float offset = 5;

    public void ClearLevel()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        for(int i=children.Length-1; i>0; i--)
        {
            DestroyImmediate(children[i].gameObject);
        }
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

    void SpawnTile(int x, int z)
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
