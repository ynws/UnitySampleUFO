using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        // Updateが呼び出されるのはframeごと。
        // 処理落ち等で更新タイミングが一定にならないことがあるので、
        // Time.deltaTimeを使って実時間に合わせた動きにする。
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
	}
}
