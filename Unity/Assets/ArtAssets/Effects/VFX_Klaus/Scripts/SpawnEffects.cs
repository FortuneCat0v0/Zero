using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnEffects : MonoBehaviour
{
    public GameObject[] Effects;

    Camera cam;
    int selectedPrefab = 0;
    int rayDistance = 300;
    private Text prefabName;

    void Start()
    {
        cam = GetComponent<Camera>();
        prefabName = GameObject.Find("PrefabName").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedPrefab++;
            if (selectedPrefab >= Effects.Length)
            {
                selectedPrefab = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedPrefab--;
            if (selectedPrefab < 0)
            {
                selectedPrefab = Effects.Length - 1;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3[] spawnData = GetClickPosition();
            if (spawnData[0] != Vector3.zero)
            {
                GameObject spawnPS = Instantiate(Effects[selectedPrefab], spawnData[0], Quaternion.FromToRotation(Effects[selectedPrefab].transform.up, spawnData[1]));
                var prefabPS = spawnPS.GetComponent<ParticleSystem>();
                if (prefabPS != null)
                {
                    Destroy(spawnPS, prefabPS.main.duration);
                }
                else
                {
                    var psChild = spawnPS.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(spawnPS, psChild.main.duration);
                }
            }
        }

        if (Effects.Length > 0 && selectedPrefab >= 0 && selectedPrefab < Effects.Length)
        {
            prefabName.text = Effects[selectedPrefab].name;
        }
    }

    Vector3[] GetClickPosition()
    {
        Vector3[] returnData = new Vector3[] { Vector3.zero, Vector3.zero };
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            returnData[0] = hit.point;
            returnData[1] = hit.normal;
        }
        return returnData;
    }
}