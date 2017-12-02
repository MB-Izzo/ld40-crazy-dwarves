using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    [SerializeField]
    private GameObject _building_prefab;

    private static BuildingManager _instance;
	public static BuildingManager Instance { get { return _instance; } }

	public List<Building> buildings { get; set; }

    public delegate void EventOnBuildingCreated(Building new_building);
    public EventOnBuildingCreated OnBuildingCreated;

	// Use this for initialization
	void Start () {
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
        // HACK ----------------------------
        if ( Input.GetKeyUp(KeyCode.Space))
        {
            CreateBuilding();
        }
        // ---------------------------------
    }

    private void CreateBuilding()
    {
        // HACK ----------------------------
        // TODO: Factory in charge of building creation + state machine
        GameObject new_building = Instantiate<GameObject>(_building_prefab);
        new_building.transform.position = new Vector3(Random.value * 10.0f - 5.0f, Random.value * 10.0f - 5.0f, Random.value * 10.0f - 5.0f);
        Building b = new_building.GetComponent<Building>();
        buildings.Add(b);
        if (OnBuildingCreated != null)
            OnBuildingCreated(b);
        // ---------------------------------

    }
}
