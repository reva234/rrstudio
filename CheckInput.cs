using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInput{

	public static bool checkTouch(Collider2D collider){
		bool ret = false;
		Vector2 pos = Vector2.zero;
		#if UNITY_ANDROID
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began){
			pos = Input.GetTouch(0).position;
		}
		#endif
		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0)){
			pos = Input.mousePosition;
		}
		#endif
		Vector3 wp = Camera.main.ScreenToWorldPoint (pos);
		Vector2 touchPos = new Vector2 (wp.x, wp.y);

		ret = collider.OverlapPoint (touchPos);
		return ret;
	}
}
