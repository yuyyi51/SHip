using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fighterBullet : MonoBehaviour {
    public float speed = 10;
    float time = 0;
    public float maxDis = 30;
    public float damage = 5;
    public GameObject explode;

    bool is_enemy;

	// Use this for initialization
	void Start () {
        is_enemy = GetComponent<is_en_tag>().is_enemy;

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        is_en_tag ctag = collision.GetComponent<is_en_tag>();
        if(ctag.tag_kind==is_en_tag.kind.plane && is_enemy != ctag.is_enemy)
        {
            explode.transform.localScale = new Vector3(.01f, .01f);
            Instantiate(explode, transform.position, transform.rotation);
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update () {
        if (speed * time > maxDis) Destroy(this);
        else
        {
            time += Time.deltaTime;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
	}
}
