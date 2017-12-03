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

    public delegate void EventOnSellAvailable(Building new_building);
    public EventOnSellAvailable OnSellAvalaible;

    // Placer
    private GameObject currently_placing_obj;
    public GameObject brewery_prefab;
    public GameObject kitchen_prefab;

    private string _current_building_name;

    private Building _cart;
    

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

        CallForDwarfWork();
        CallForSell();

      
    }

    private void CallForDwarfWork()
    {

        foreach(Building b in buildings)
        {
            if (b is BeerMaker)
            {
                if (b.is_being_used == false && ResourcesManager.Instance.NeedBeer())
                {
                    OnDwarfNeeded(b);
                }
            }

            if (b is Kitchen)
            {
                if (b.is_being_used == false && ResourcesManager.Instance.NeedMeat())
                {
                    OnDwarfNeeded(b);
                }
            }
           
        }
    }

    private void CallForSell()
    {
        if (ResourcesManager.Instance.CanSell())
        {
            if (OnSellAvalaible != null)
            {
                OnSellAvalaible(_cart);
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
		currently_placing_obj = Instantiate(brewery_prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
		currently_placing_obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        _current_building_name = "brewery";

	}

    public void BuildKitchen()
    {
        currently_placing_obj = Instantiate(kitchen_prefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity) as GameObject;
		currently_placing_obj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        _current_building_name = "kitchen";
    }
}
