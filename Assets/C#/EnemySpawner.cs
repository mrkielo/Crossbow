using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
    [SerializeField] GameObject[] enemies;

    [SerializeField] int[] intensity;
    [SerializeField] float duration;

    float delay;
    bool nextWave = true;
    float startTime;
    Vector2 screenBounds;

    void Start() {
        screenBounds.x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x;
        screenBounds.y = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y;
        Debug.Log(screenBounds.x);

    }

    void Update() {

       if(startTime+duration> Time.time && nextWave) {
           StartCoroutine("Timing");
       }
    }

    void Win() {
    
    }

    void GameOver() {

    }

    float Wave(GameObject enemy, int level) {
        Vector2 pos;
        float enemyWidth = enemy.transform.lossyScale.x;
        float enemyHeight = enemy.transform.lossyScale.y;
        float maxPos = screenBounds.x - enemyWidth/2;
        switch(level) {
            case 1:
                pos.y = transform.position.y;
                pos.x = Random.Range(-maxPos,maxPos);
                Spawn(enemy,pos);
                return Random.Range(1f,5f);
            case 2:
                pos.y = transform.position.y;
                pos.x = Random.Range(-maxPos,maxPos);
                Spawn(enemy,pos);
                return Random.Range(0,1.5f);
            case 3:
                pos.x = Random.Range(-maxPos+enemyWidth/2,maxPos-enemyWidth/2);
                pos.y = transform.position.y;
                Spawn(enemy,pos);
                pos.x-=enemyWidth/2;
                pos.y+=enemyHeight;
                Spawn(enemy,pos);
                pos.x+=enemyWidth;
                Spawn(enemy,pos);
                return Random.Range(3f,6f);            
        }

        return 0;
    }
    
    void Spawn(GameObject enemy,Vector2 pos) {
        Instantiate(enemy,pos,transform.rotation);
    }

    IEnumerator Timing() {
        nextWave = false;
        yield return new WaitForSeconds(delay);
        
        int index = Random.Range(0,enemies.Length);
        delay = Wave(enemies[index],Random.Range(1,intensity[index]+1));
        nextWave = true;
    }

    int GetMaxIndexFromArray(int[] array) {
        int index=0;
        int max = 0;
        for(int i=0;i<array.Length;i++) {
            if(array[i]>max) {
                max=array[i];
                index = i;
            }

        }
        return index;
    }
}
