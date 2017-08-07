using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour {

	private MapGameObjectList m_mapGameObjectList;


	void Awake()
	{
		m_mapGameObjectList = GetComponent<MapGameObjectList>();
	}

	public MapGameObjectList GetUnitGameObject()
	{
		return m_mapGameObjectList;
	}


}
