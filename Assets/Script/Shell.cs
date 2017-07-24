using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {

	public float timetodestroy = 5;
	public float speed = 15;
	public float damage = 5;

    private Vector3 direction;


	// Use this for initialization
	void Start () {
        Vector3 shiptoward;
        float shipspeed;

        shiptoward = ShipMove.instance.transform.up;
		shiptoward.Normalize();
        shipspeed = ShipMove.instance.Speed;
        //Debug.Log(shipspeed);
        shiptoward *= shipspeed;
        //Debug.Log(shiptoward);

        direction = transform.up;
        direction.Normalize();
        direction *= speed;
        //Debug.Log(direction);

        direction += shiptoward;
        //Debug.Log(direction);
        speed = direction.magnitude;
        direction = transform.InverseTransformVector(direction);
        
        //Debug.Log(speed);
        direction.Normalize();
        //Debug.Log(direction);
	}
	
	// Update is called once per frame
	void Update () {
        timetodestroy = timetodestroy - Time.deltaTime;
        gameObject.transform.Translate(direction * speed * Time.deltaTime);
        //Debug.Log(transform.position);

		if (timetodestroy < 0) {
			Destroy(gameObject);
		}    
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<is_en_tag>().tag_kind == is_en_tag.kind.ship && other.GetComponent<is_en_tag>().is_enemy != gameObject.GetComponent<is_en_tag>().is_enemy)
        {

            Destroy(gameObject);

        }
    }


}
