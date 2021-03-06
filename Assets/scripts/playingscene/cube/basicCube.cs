﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class basicCube : MonoBehaviour {
	static float velocity;
	static float precision;
	public static float highVelocity = 20;
	public static float greatPrecision = 0.1f;
	public static float lowVelocity = 1;
	public static float smallPrecision = 0.03f;
	public static float commonVelocity = 11;
	public static float commonPrecision = 0.03f;

	static int destroyNumber = 0;

	bool punish = false;

	public bool arrived = false;
	bool onGround = false;
	public float destination;
	public float cubeLength = 1.2f;
	public List<List<GameObject>> map;
	public int[] top;
	private int _indexX;
	public int indexX
	{
		get{return _indexX;}
		set{ _indexX = value;}
	}
	private int _indexY;
	public int indexY
	{
		get{return _indexY; }
		set{if (value < 0)
				_indexY = 0;
			else if (value > 11)
				_indexX = 11;
			else
				_indexY = value;
		}
	}

	float fixedDeltatime = 0.01f;
	//因为自己封装了destroy方法，有时候会重复调用导致出错，所以用exist保证destroy方法只会调用一次
	bool exist = true;

//	float time = 0;
	void Start () {
//		transform.GetComponent<Rigidbody2D> ().velocity = new Vector3(0,-commonVelocity,0);
		destination = transform.position.y;
	}

	void Update()
	{
//		float deltatime = Time.deltaTime;
//		time += deltatime;
//		if (time <= 1.5f)
//			velocity += commonVelocity * deltatime / 1.5f;
	}

	void FixedUpdate()
	{
		if (arrived) {
			if (indexY > 0 && !map [indexX] [indexY - 1])
				down ();
		} 
		else {
			if (transform.position.y < destination) {
				transform.position += new Vector3 (0, destination - transform.position.y, 0);
				arrive ();
			} else {
				if (map [indexX] [indexY])
					up ();
				if (!punish) {
					if (Mathf.Abs (destination - transform.position.y) < precision)
						arrive ();
					else
						transform.position -= new Vector3 (0, velocity * fixedDeltatime, 0);
				}
				else {
					if (Mathf.Abs (destination - transform.position.y) < greatPrecision) 
						arrive ();
					else
						transform.position -= new Vector3 (0, highVelocity * fixedDeltatime, 0);
				}			
			}
		}
	}

	public void _goto(float des)
	{
		destination = des;
		arrived = false;
	}

	public void down()
	{
		destination = destination - cubeLength - 0.05f;
		map [indexX] [indexY] = null;
		_goto (destination);
		indexY -= 1;
//		transform.GetComponent<Rigidbody2D> ().velocity = new Vector3(0,-commonVelocity,0);
	}

	//用来矫正某些时候两个方方块部分重叠在一起，最后落在同一个地方的bug
	public void up()
	{
		destination = destination + cubeLength + 0.05f;
		_goto (destination);
		indexY += 1;
	}

//	void OnTriggerEnter2D()
//	{
//		arrive ();
//		print ("arrive");
//	}

	void arrive()
	{
		if (indexY == 0 || map [indexX] [indexY - 1])
		if (!onGround) {
			onGround = true;
			top [indexX]++;
			//方块第一次落地后，会关闭方块的误点击惩罚功能
			if(indexY>0)
				inactivatepunish ();
		}
		transform.position = new Vector3(transform.position.x, destination,transform.position.z);
		arrived = true;
		map [indexX] [indexY] = gameObject;

//		transform.GetComponent<Rigidbody2D> ().velocity = new Vector3(0,0,0);
	} 	

	public bool getArriveState()
	{
		return arrived && onGround;
	}
	public bool isEffectAvailable()
	{
		return indexY < 3;
	}

	public void destroy()
	{
		if (!exist)
			return;
		exist = false;
		map[indexX][indexY] = null;
		if(getArriveState())
			top [indexX]--;
		destroyNumber++;
		print ("destroy "+indexX+" "+indexY);
		Destroy (gameObject);
	}

	static public void slowDown()
	{
		velocity = lowVelocity;
		precision = smallPrecision;
	}
	static public void recoverVelocity()
	{
		velocity = commonVelocity;
		precision = commonPrecision;
	}
	static public void pause()
	{
		velocity = 0;
	}
	static public void init()
	{
		destroyNumber = 0;
		velocity = commonVelocity;
		precision = commonPrecision;
	}
	static public int getDestroyNumber()
	{
		return destroyNumber;
	}

	public void activatePunish()
	{
		punish = true;
	}
	public void inactivatepunish()
	{
		punish = false;
		if(GetComponent<punishCube>())
			GetComponent<punishCube> ().enabled = false;
	}


}
