using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {

	public GameObject beer_maker_prefab;
	private bool placing;
	private GameObject currently_placing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (currently_placing != null)
		{
			currently_placing.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, 0);
			if (Input.GetMouseButton(0))
			{
				currently_placing.GetComponent<SpriteRenderer>().color = new Color(255,255,255, 1);
				GameObject go = Instantiate(currently_placing, currently_placing.transform.position, Quaternion.identity) as GameObject;
				Building building = go.GetComponent<Building>();
				BuildingManager.Instance.buildings.Add(building);
				Destroy(currently_placing);
			}
		}
	}

	public void BuildBeerMaker()
	{
		GameObject go = Instantiate(beer_maker_prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
		go.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
		placing = true;
		currently_placing = go;
	}
}
