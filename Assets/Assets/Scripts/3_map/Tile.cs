using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	private int m_TileID = 0;

	public void setTileID(int id)
	{
		m_TileID = id;
	}
	public int getTileID()
	{
		return m_TileID;
	}

	private CommonTypes.eTileStatus m_type;

	public void setTileType(CommonTypes.eTileStatus type)
	{
		m_type = type;
	}
	public CommonTypes.eTileStatus getTileType()
	{
		return m_type;
	}


}
