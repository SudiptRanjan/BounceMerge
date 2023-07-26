using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
   [SerializeField] private Block blockPrefab;
    int numberOfRaws;
    private void OnEnable()
    {
        SpawnBlocks();
    }

    private void SpawnBlocks()
    {
        var createdBlocks = Instantiate(blockPrefab, transform.position, Quaternion.identity);
            int blockValue = UnityEngine.Random.Range(1, 5) + numberOfRaws;
        createdBlocks.SetBlockNo(blockValue);
    }
}
