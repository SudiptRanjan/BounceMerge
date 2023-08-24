using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    public float distance = 4;
    public List<Block> listOfBlocks;
    public List<Color> colors = new List<Color>();
    public BallLauncher ballLauncher;
    public int multiplyer = 1;
    public  int blockValue;
     int   minValue =100;
    public Ball ball;
    private void Start()
    {
        //blockcount = listOfBlocks.Count;
        //SpawnBlocks();
        //SpawnBlocks();
        //SpawnBlocks();
    }
    private void OnEnable()
    {
        SpawnBlocks();
        BallsCollection.BlocksSpawn += SpawnBlocks;
        Block.RemoveBallFromlist += RemoveBalls;
        GameOver.OnGameOverClearList += ClearAllBlocks;
    }
    private void OnDisable()
    {
        BallsCollection.BlocksSpawn -= SpawnBlocks;
        Block.RemoveBallFromlist -= RemoveBalls;
        GameOver.OnGameOverClearList -= ClearAllBlocks;
    }

    private void Update()
    {
        //for (int i = 0; i < listOfBlocks.Count; i++)
        //{
        //    if (blockValue > minValue)
        //    {
        //        ball.IncreaseBallNo();
        //        minValue += 100;
        //        //Debug.Log("the value blockValue =" + blockValue);
        //    }
        //    return;
        //}
    }
    public void RemoveBalls(Block block)
    {
        listOfBlocks.Remove(block);
    }

    public void ClearAllBlocks()
    {
        for (int i = listOfBlocks.Count-1; i >=0 ; i--)
        {
            //Debug.Log("blocks deleted");
            Block block = listOfBlocks[i];
            Destroy(block.gameObject);
            listOfBlocks.RemoveAt(i);

        }
    }

   

    public void SpawnBlocks()
    {
        //Debug.Log("spawn block calling");
        Vector3 xyz = new Vector3(0, 0, 45);
        Quaternion newRotation = Quaternion.Euler(xyz);
        //Debug.Log("block spawned");
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
                   Block createdBlocks = Instantiate(blockPrefab, position, newRotation);
                   createdBlocks.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Count)];
                    blockValue = Random.Range(4, 8 * multiplyer*multiplyer);
                   createdBlocks.SetBlockNo(blockValue);
                   listOfBlocks.Add(createdBlocks);
                //Debug.Log(blockValue);
                //for (int j = 0; j < listOfBlocks.Count; j++)
                //{
                //    if (blockValue > minValue)
                //    {
                //        ball.IncreaseBallNo();
                //        minValue = 300;
                //        //Debug.Log("the value blockValue =" + blockValue);
                //    }
                    
                //}
            }
        }
        multiplyer++;

        //Debug.Log(blockValue);
        //for (int i = 0; i < listOfBlocks.Count; i++)
        //{
        //    if (blockValue > minValue)
        //    {
        //        ball.IncreaseBallNo();
        //        minValue += 100;
        //        //Debug.Log("the value blockValue =" + blockValue);
        //    }
        //    return;
        //}



    }
}

