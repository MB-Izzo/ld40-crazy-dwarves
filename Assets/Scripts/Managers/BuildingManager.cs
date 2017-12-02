using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    [SerializeField]
    private GameObject _building_prefab;

    private static BuildingManager _instance;
	public static BuildingManager Instance { get { return _instance; } }

	public List<Building> buildings { get; set; }

    public delegate void EventOnDwarfNeeded(Building new_building);
    public EventOnDwarfNeeded OnDwarfNeeded;

    // Placer
    private GameObject currently_placing_obj;
    public GameObject brewery_prefab;
    

	// Use this for initialization
	void Awake () {
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}

		buildings = new List<Building>();
	}


    private void Update()
    {
        if (currently_placing_obj != null)
		{
			currently_placing_obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, 0);
			if (Input.GetMouseButton(0))
			{
                CreateBuilding();
			}
		}

        CallForDwarf();
    }

    private void CallForDwarf()
    {
        foreach(BeerMaker building in buildings)
        {
            if (building.is_being_used == false && ResourcesManager.Instance.beer <= 5)
            {
                OnDwarfNeeded(building);
            }
        }
    }

    private void CreateBuilding()
    {
        // HACK ----------------------------
        // TODO: Factory in charge of building creation + state machine
        GameObject new_building = Instantiate<GameObject>(_building_prefab);
        new_building.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, 0);
        Building b = new_building.GetComponent<Building>();
        buildings.Add(b);
        Destroy(currently_placing_obj);
        //if (OnDwarfNeeded != null)
          //  OnDwarfNeeded(b);
        // ---------------------------------
    }

    public void BuildBrewery()
	{
		GameObject go = Instantiate(brewery_prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
		go.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
		currently_placing_obj = go;
	}
}
