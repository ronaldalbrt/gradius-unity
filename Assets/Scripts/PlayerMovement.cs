﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    float mvx;
    float mvy;
    double deathtime;
    public GameObject prefab;
    public GameObject[] enemyprefab =  new GameObject[5];
    GameObject[] shot = new GameObject[5];
    public float speed;
    public bool dying;
    double time;
	void Start ()
    {
        speed = 5;
	}
	void Update ()
    {
        time += Time.deltaTime;
        if(dying)
        {
            deathtime = Time.deltaTime;
            this.GetComponent<Animator>().SetTrigger("Death");
            if(deathtime > 0.5)
            {
                Destroy(this.gameObject);
            }
        }
        if(time > 3)
        {
            Instantiate(enemyprefab[Random.Range(0, 3)], new Vector3(6, Random.Range(-5, 5)), new Quaternion(0f, 0f, 0f, 0f));
            time = 0;
        }
        mvx = Input.GetAxis("Horizontal");
        mvy = Input.GetAxis("Vertical");
        this.transform.position += new Vector3(mvx * speed * Time.deltaTime, mvy * speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < shot.Length; i++)
            {
                if(shot[i] == null)
                {
                    this.GetComponent<AudioSource>().Play();
                    shot[i] = (GameObject)Instantiate(prefab, this.transform.position + new Vector3(3, 0), new Quaternion(0f, 0f, 0f, 0f));
                    break;
                }
            }
        }
    }
}
