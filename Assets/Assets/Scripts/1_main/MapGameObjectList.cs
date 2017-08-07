using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGameObjectList : MonoBehaviour{

	private Dictionary<int, GameObject> m_mapObjList = new Dictionary<int, GameObject>();

	public Dictionary<int, GameObject> GetMapObjectList()
	{
		if (m_mapObjList.Count == 0) return null;

		return m_mapObjList;
	}

	public GameObject GetMapGameObject(int unique_id)
	{
		GameObject objChacker;
		if (!m_mapObjList.TryGetValue(unique_id, out objChacker))
		{
			return null;
		}
		return m_mapObjList[unique_id];
	}
	public void SetMapGameObject(int unique_id, ref GameObject obj)
	{
		if (obj == null)
		{
			return;
		}
		m_mapObjList.Add(unique_id, obj);
	}

	public int MapObjectCount()
	{
		if (m_mapObjList == null) { return 0; }

		return m_mapObjList.Count;
	}

}
