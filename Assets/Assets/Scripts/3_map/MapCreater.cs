﻿using System.Collections;
{

	void Start()
	{
		TileCreate();
	}




			MapTileSetting(mapTile);
		}
		for (int lh = 0; lh < 5; lh++)
		{
			GameObject mapTile = Instantiate(load_tile) as GameObject;
			if (mapTile == null) return;

			MapTileSetting(mapTile);
			TileVertex(mapTile, m_mpaTileVertexList[1], lh);
		}
		{
			GameObject mapTile = Instantiate(load_tile) as GameObject;

			MapTileSetting(mapTile);
		}
		{
			GameObject mapTile = Instantiate(load_tile) as GameObject;
			if (mapTile == null) return;

			MapTileSetting(mapTile);
			TileVertex(mapTile, m_mpaTileVertexList[3], rd);
		}
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
			float tilePosX = vertex.x + (index * obj.transform.localScale.x);
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
	}