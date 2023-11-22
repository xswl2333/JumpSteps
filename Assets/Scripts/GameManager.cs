using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public GameObject groundPrefab;
    public GameObject goalPrefab;
    public int spawnAmount;
    public Vector2 step = new Vector2(4.55f, 7.5f);
    // Start is called before the first frame update
    void Start()
    {
        spawnNewWave();
    }

    void spawnNewWave()
    {
        Vector2 spawnPos = Vector2.zero;
        for(int i=0;i<spawnAmount;i++)
        {
            int swapnDir = Random.Range(0, 1f) > 0.5f ? -1 : 1;
            spawnPos += new Vector2(step.x * swapnDir, step.y);
            GameObject ground = new GameObject();

            if(i!=spawnAmount-1)
            {
                ground = Instantiate(groundPrefab, spawnPos - Vector2.up * 2, Quaternion.identity);
            }
            else
            {
                ground = Instantiate(goalPrefab, spawnPos - Vector2.up * 2, Quaternion.identity);

            }
            ground.transform.parent= transform;
            ground.transform.DOMove(ground.transform.position + Vector3.up * 2f, 0.5f).SetDelay(i*0.1f);//Vector3
        }
    }
}
