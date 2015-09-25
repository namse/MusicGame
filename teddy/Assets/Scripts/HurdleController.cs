using UnityEngine;
using System.Collections;

public class HurdleController: MonoBehaviour {

	public Flower FlowerPrefab;
	// Use this for initialization
	void Start () {
		Koba_Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Koba_Init(){

		float moveSpeed = PlatformController.moveSpeed;
		// first Flower until 00:20:50 // 30박
		for (float i = 3.10f; i < 30; i+= 4f) {
			float bps = 89f / 60f;
			float distancePerBeat = moveSpeed / bps;
			float x = i * distancePerBeat;
			Instantiate (FlowerPrefab, new Vector3(x, 0, 0), Quaternion.identity);
		}

		/*for (float i = 1 / (89 / 60) * 3; i < 20.5; i += 1 / (89 / 60) * 4) {
			float x = i * 3.357215f;
			Instantiate (FlowerPrefab, new Vector3(x, 0, 0), Quaternion.identity);
		}*/

		// bpm = beats per minute
		// bps = bpm / 60
		// 1초동안 나오는 비트 갯수 = bpm / 60 = bps
		// 1초가 되기 위한 비트 갯수 = 1/bps = 1 / (bpm / 60)
		// 89->95

		// moveSpeed 5일때 89bpm에서 1박자마다 3.357215를 감.
		// 3.357215 / moveSpeed = 1초가 되기 위한 비트 갯수  = 1/bps
		// 1박자에 가는 길이 = moveSpeed / bps

		// 1/3.357215 박자마다 1를 감.
		// 1초동안 bpm/60개의 박자가 나옴. 그 박자마다 * 3.357215를 감.



	}
}
