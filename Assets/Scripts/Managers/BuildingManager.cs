using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour {

    [SerializeField]
    private GameObject _building_prefab;

    private static BuildingManager _instance;
	public static BuildingManager Instance { get { return _instance; } }

	public List<Building> buildings { get; set; }

    public delegate void EventOnDwarfNeeded(Building new_building);
    public EventOnDwarfNeeded OnDwarfNeeded;

    public delegate void EventOnSellAvailable(Building new_building);
    public EventOnSellAvailable OnSellAvalaible;

    // Placer
    private GameObject currently_placing_obj;
    public GameObject brewery_prefab;
    public int price_brewery;
    public GameObject kitchen_prefab;
    public int price_kitchen;

    private string _current_building_name;

    public Building _cart { get; set;}

    public Button buy_dwarf;
    public GameObject dwarf_prefab;
    public int price_drarf;
    

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
        _cart = FindObjectOfType<Cart>();
        buy_dwarf.onClick.AddListener(CreateDwarf);
	}


    private void Update()
    {
        if (currently_placing_obj != null)
		{
			currently_placing_obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, 0);
			if (Input.GetMouseButton(0) && !currently_placing_obj.GetComponent<Collider2D>().IsTouchingLayers(Physics2D.AllLayers))
			{
                CreateBuilding(_current_building_name);

                Destroy(currently_placing_obj.gameObject);
                currently_placing_obj = null;
			}
		}
      
    }

  

    private void CreateBuilding(string building_type)
    {
        GameObject go = null;
        GameObject new_building = null;
        switch (building_type)
        {
            case "brewery":
                go = brewery_prefab;
                new_building = Instantiate<GameObject>(go);
                BeerMaker brewery_component = new_building.GetComponent<BeerMaker>();
                buildings.Add(brewery_component);
                break;
            case "kitchen":
                go = kitchen_prefab;
                new_building = Instantiate<GameObject>(go);
                Kitchen kitchen_component = new_building.GetComponent<Kitchen>();
                buildings.Add(kitchen_component);
                break;
            default:
                break;
        }
        new_building.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, 0);
    }

    public void BuildBrewery()
	{
        if (ResourcesManager.Instance.gold >= price_brewery)
        {
            currently_placing_obj = Instantiate(brewery_prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
            currently_placing_obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            _current_building_name = "brewery";
            ResourcesManager.Instance.gold -= price_brewery;
        }
		

	}

    public void BuildKitchen()
    {
        if (ResourcesManager.Instance.gold >= price_kitchen)
        {
            currently_placing_obj = Instantiate(kitchen_prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
		    currently_placing_obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            _current_building_name = "kitchen";
            ResourcesManager.Instance.gold -= price_kitchen;

        }
    }

    private void CreateDwarf()
    {
        if (ResourcesManager.Instance.gold >= price_drarf)
        {
            Instantiate(dwarf_prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
            ResourcesManager.Instance.gold -= price_drarf;
        }
    }
}
