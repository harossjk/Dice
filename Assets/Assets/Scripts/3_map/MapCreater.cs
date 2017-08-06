using System.Collections;using System.Collections.Generic;using UnityEngine;public class MapCreater : MonoBehaviour
{	private static int m_mapIndex = 0;	//private const float ro_z = -45f;	private const float pos_z = 0f;

	void Start()
	{
		TileCreate();		this.transform.Rotate(90, 0, 0);
	}	private void TileCreate()	{
		GameObject load_tile = Resources.Load("prefabs/Tile") as GameObject;		if (load_tile == null) return;

		Vector3[] m_mpaTileVertexList = new Vector3[4];		m_mpaTileVertexList[0] = new Vector3(25, -25, pos_z);		m_mpaTileVertexList[1] = new Vector3(-25, -15, pos_z);		m_mpaTileVertexList[2] = new Vector3(-15, 25, pos_z);		m_mpaTileVertexList[3] = new Vector3(25, 15, pos_z);		for (int rw = 0; rw < 6; rw++)		{			GameObject mapTile = Instantiate(load_tile) as GameObject;			if (mapTile == null) return;

			MapTileSetting(mapTile);			TileVertex(mapTile, m_mpaTileVertexList[0], rw);
		}
		for (int lh = 0; lh < 5; lh++)
		{
			GameObject mapTile = Instantiate(load_tile) as GameObject;
			if (mapTile == null) return;

			MapTileSetting(mapTile);
			TileVertex(mapTile, m_mpaTileVertexList[1], lh);
		}		for (int lw = 0; lw < 5; lw++)
		{
			GameObject mapTile = Instantiate(load_tile) as GameObject;			if (mapTile == null) return;

			MapTileSetting(mapTile);			TileVertex(mapTile, m_mpaTileVertexList[2], lw);
		}		for (int rd = 0; rd < 4; rd++)
		{
			GameObject mapTile = Instantiate(load_tile) as GameObject;
			if (mapTile == null) return;

			MapTileSetting(mapTile);
			TileVertex(mapTile, m_mpaTileVertexList[3], rd);
		}	}
	private void MapTileSetting(GameObject _tile)
	{
		int index = MapTileIndexGenerator();
		Tile tileScrlipt = _tile.GetComponent<Tile>();

		tileScrlipt.setTileID(index);
		tileScrlipt.setTileType(CommonTypes.eTileStatus.TILE_TYPE_NONE);

		_tile.transform.name = "Tile_" + tileScrlipt.getTileID() + "_" + tileScrlipt.getTileType();
		_tile.transform.parent = this.transform;
	}

	private void TileVertex(GameObject obj, Vector3 vertex, int index)
	{
		if (obj.GetComponent<Tile>().getTileID() < 6)
		{
			float tilePosX = vertex.x - (index * obj.transform.localScale.x);
			obj.transform.position = new Vector3(tilePosX, vertex.y, vertex.z);
		}
		else if (obj.GetComponent<Tile>().getTileID() > 5 && obj.GetComponent<Tile>().getTileID() < 12)
		{
			float tilePosY = vertex.y + (index * obj.transform.lossyScale.y);
			obj.transform.position = new Vector3(vertex.x, tilePosY, vertex.z);
		}
		else if (obj.GetComponent<Tile>().getTileID() > 11 && obj.GetComponent<Tile>().getTileID() < 16)
		{
			float tilePosX = vertex.x + (index * obj.transform.localScale.x);			obj.transform.position = new Vector3(tilePosX, vertex.y, vertex.z);
		}
		else if (obj.GetComponent<Tile>().getTileID() > 15 && obj.GetComponent<Tile>().getTileID() <= 19)
		{
			float tilePosY = vertex.y - (index * obj.transform.lossyScale.y);
			obj.transform.position = new Vector3(vertex.x, tilePosY, vertex.z);
		}
	}

	private static int MapTileIndexGenerator()
	{
		return m_mapIndex++;
	}}