using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    public float distance = 4;
    private int multiplyer = 1;
    public List<Block> listOfBlocks;
    public static BlockSpawner instance;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        SpawnBlocks();
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
        for(int i = 0;i<4;i++)
        {

            Vector3 position = transform.position;
            position +=- distance * i * Vector3.right;
            Block createdBlocks = Instantiate(blockPrefab, position, Quaternion.identity);
            int blockValue = Random.Range(1, 5 * multiplyer);
            createdBlocks.SetBlockNo(blockValue);
            listOfBlocks.Add(createdBlocks);


        }
        multiplyer++;
      
    }
}
