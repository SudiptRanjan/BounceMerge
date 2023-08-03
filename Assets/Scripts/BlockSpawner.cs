using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    public float distance = 4;
    private int multiplyer = 1;
    public List<Block> listOfBlocks;
    public List<Color> colors = new List<Color>();

    public BallLauncher ballLauncher;

    private void OnEnable()
    {
        SpawnBlocks();
        BallsCollection.BlocksSpawn += SpawnBlocks;
        Block.RemoveBallFromlist += RemoveBalls;
    }
    private void OnDisable()
    {
        BallsCollection.BlocksSpawn -= SpawnBlocks;
        Block.RemoveBallFromlist -= RemoveBalls;
    }

    public void RemoveBalls(Block block)
    {
        listOfBlocks.Remove(block);
    }

    public void SpawnBlocks()
    {
        foreach (Block block in listOfBlocks)
        {
            if(block != null)
            {
                block.transform.position += Vector3.up * distance;

            }
        }


        for (int i = 0; i < 4; i++)
        {
            if (Random.Range(0, 100) > 40)
            {
                   Vector3 position = transform.position;
                   position += -distance * i * Vector3.right;
                   Block createdBlocks = Instantiate(blockPrefab, position, Quaternion.identity);
                   createdBlocks.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Count)];
                   int blockValue = Random.Range(1, 5 * multiplyer);
                   createdBlocks.SetBlockNo(blockValue);
                   listOfBlocks.Add(createdBlocks);
            }
        }
        
        
        multiplyer++;
      
      
    }
}

