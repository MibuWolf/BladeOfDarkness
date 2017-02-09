using UnityEngine;
using System.Collections;

public class Global {

	public string loadName;
	private static Global instance;
	public static Global GetInstance () {
		if (instance == null) {
			instance = new Global();
		}
		return instance;
	}
}
