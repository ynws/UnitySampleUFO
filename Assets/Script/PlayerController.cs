using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2d;

    // 収集アイテム数。PlayerControllerが持ってるのは変じゃないか？
    // まぁ、チュートリアルだから簡略化されてるだけだろうけど。
    private int count;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // frameごとの状態更新。ただし、物理演算の直前に呼ばれるので動きの制御に使うこと。
    // ロジック的な毎frame処理はUpdate()で
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    // 衝突処理に入った時の処理。実際の衝突の前に実行される
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        // pickupの合計数をPlayerが知っているのは変。
        // countの保持とともに、ステージ管理用objでも作ってそっちに投げるのが自然。
        // まぁ、チュートリアルなので。
        if(count >= 8)
        {
            winText.text = "Win";
        }
    }
}
