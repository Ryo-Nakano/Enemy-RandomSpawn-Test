using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	[SerializeField] GameObject[] enemyType = new GameObject[3];//Unity上からアタッチ！
	//0→Red
	//1→Blue
	//2→Green

	float enemySpawnInterval;
	[SerializeField] float enemySpawnTimer;

	float enemySpawnPositionX;//Enemyが生成される座標のX座標に対応！
	Vector3 enemySpawnPosition;
	Vector3[] enemySpawnPositions;

	// Use this for initialization
	void Start () {

		//enemySpawnPositionsの内容を定義
//		enemySpawnPositions = new Vector3[]
//		{
//			enemySpawnPosition,//enemySpawnPositions[0]
//			enemySpawnPosition + new Vector3 (2, -1, 0),//enemySpawnPositions[1]
//			enemySpawnPosition + new Vector3 (4, 0, 0),//enemySpawnPositions[2]
//			enemySpawnPosition + new Vector3 (4, 2, 0),//enemySpawnPositions[3]
//			enemySpawnPosition + new Vector3 (2, 3, 0),//enemySpawnPositions[4]
//			enemySpawnPosition + new Vector3 (0, 2, 0),//enemySpawnPositions[5]
//		};


		enemySpawnInterval = Random.Range (2,5);
	}
	
	// Update is called once per frame
	void Update () {

		EnemySpawn ();

	}

	//円環状にenemyを生成する関数
	void EnemySpawn()
	{

		enemySpawnTimer -= Time.deltaTime;//enemy生成のtimer
		enemySpawnPosition += new Vector3 (enemySpawnInterval * Time.deltaTime, 0, 0);

		if(enemySpawnTimer < 0)
		{
			enemySpawnPositions = new Vector3[]
			{
				enemySpawnPosition,//enemySpawnPositions[0]
				enemySpawnPosition + new Vector3 (2, -1, 0),//enemySpawnPositions[1]
				enemySpawnPosition + new Vector3 (4, 0, 0),//enemySpawnPositions[2]
				enemySpawnPosition + new Vector3 (4, 2, 0),//enemySpawnPositions[3]
				enemySpawnPosition + new Vector3 (2, 3, 0),//enemySpawnPositions[4]
				enemySpawnPosition + new Vector3 (0, 2, 0),//enemySpawnPositions[5]
			};

			for(int i = 0; i < enemySpawnPositions.Length; i++){//enemySpawnPositionsの要素数だけ回す！

				//ランダムな種類のenemy生成
				Instantiate(enemyType[Random.Range(0,3)], enemySpawnPositions[i], Quaternion.identity);
			}

			enemySpawnTimer = Random.Range (2, 5);//タイマーの初期値再設定
		}


	}
}
