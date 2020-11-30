using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectsScript : MonoBehaviour
{
	public GameObject elmPrefab;
	public GameObject pinePrefab;
	public GameObject ashPrefab;
	public GameObject bushPrefab;

	// Start is called before the first frame update
	void Start()
	{


		for (int i = 0; i < 100; i++)
		{
			// Choose a random position over the terrain
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 5, z);
			// Use sample height at that position to find out what y should be.
			float y = Terrain.activeTerrain.SampleHeight(pos);
			pos.y = y;
			// Instantiate the tree at that position.
			GameObject elm = Instantiate(elmPrefab, pos, Quaternion.identity);
			// Randomly rotate the tree on the y axis for variation
			elm.transform.Rotate(0, Random.Range(0, 360), 0);
		}

		// Instantiate a bunch of rings all around the terrain (same process as with the tree)
		for (int i = 0; i < 100; i++)
		{
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 5, z);
			float y = Terrain.activeTerrain.SampleHeight(pos);
			pos.y = y;
			GameObject pine = Instantiate(pinePrefab, pos, Quaternion.identity);
			pine.transform.Rotate(0, Random.Range(0, 360), 0);
		}

		for (int i = 0; i < 100; i++)
		{
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 5, z);
			float y = Terrain.activeTerrain.SampleHeight(pos);
			pos.y = y;
			GameObject ash = Instantiate(ashPrefab, pos, Quaternion.identity);
			ash.transform.Rotate(0, Random.Range(0, 360), 0);
		}

		for (int i = 0; i < 100; i++)
		{
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 5, z);
			float y = Terrain.activeTerrain.SampleHeight(pos);
			pos.y = y;
			GameObject bush = Instantiate(bushPrefab, pos, Quaternion.identity);
			bush.transform.Rotate(0, Random.Range(0, 360), 0);
		}


	}

}
