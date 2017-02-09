using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour 
{
	public Transform cameraTransform;
	
	private Vector3 _currentPosition;		//记录抖动前的位置
	private float _shakeCD = 0.002f;		//抖动的频率
	private int _shakeCount = -1;			//设置抖动次数
	private float _shakeTime;
	
	void Start ()
	{
		if(cameraTransform == null) cameraTransform = transform;
		
		_currentPosition = cameraTransform.position;	//记录抖动前的位置
		_shakeCount = Random.Range (50, 60);			//设置抖动次数
	}
	
	void Update ()
	{
		if(_shakeTime + _shakeCD < Time.time && _shakeCount > 0)
		{
			_shakeCount --;
			float radio = Random.Range (-0.01f, 0.01f);
			
			if(_shakeCount == 1)	//抖动最后一次时设置为都动前记录的位置
				radio = 0;
			
			_shakeTime = Time.time;
			cameraTransform.position = _currentPosition + Vector3.one * radio;
		}
	}
}
