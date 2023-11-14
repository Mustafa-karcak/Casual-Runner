using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
  public static ChunkManager instance;

    [Header("Elements")]
    [SerializeField] private LevelSO[] levels;
    private GameObject finishLine;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }

    void Start()
    {
        GenerateLevel();
        finishLine = GameObject.FindWithTag("Finish");
    
    }

    private void GenerateLevel()
    {
       int currentLevel = GetLevel();
      currentLevel = currentLevel % levels.Length;
     
        LevelSO level = levels[currentLevel];

        CreateLevel(level.chunks);
    }

   

 
    
    private void CreateLevel(Chunk[] ChunkLevel)
    {
        Vector3 ChunkPosition = Vector3.zero;

        for (int i = 0; i < ChunkLevel.Length; i++)
        {
            Chunk chunkToCreate = ChunkLevel[i];

            if (i > 0)

                ChunkPosition.z += chunkToCreate.GetLength() / 2;


            Chunk chunkInstance = Instantiate(chunkToCreate, ChunkPosition, Quaternion.identity, transform);

            ChunkPosition.z += chunkInstance.GetLength() / 2;

        }
    }
    public float GetFinishZ()
    {
        return finishLine.transform.position.z;

    }
    public int GetLevel()
    {
       return PlayerPrefs.GetInt("level",0);
    }


}
