using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaController : MonoBehaviour
{
    private SeaController instance;
    private GameObject ship;
    [SerializeField] private GameObject nextSea;
    void Start()
    {
        instance = this;
        // ship find by tag "player"
        ship = GameObject.FindGameObjectWithTag("Player");
    }
    public SeaController GetInstance()
    {
        return instance;
    }
    public void EndOfTheSea(GameObject curretSea)
    {
        // destroy all tagged "sea" objects unless the current sea object
        foreach (GameObject sea in GameObject.FindGameObjectsWithTag("Sea"))
        {
            if (sea != curretSea)
            {
                Destroy(sea);
            }
        }
        // instantiate new sea objects
        StartCoroutine(InstantiateSeas(curretSea));
    }
    private IEnumerator InstantiateSeas(GameObject curretSea){
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x, curretSea.transform.position.y, curretSea.transform.position.z - 1500), Quaternion.identity, this.transform);
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x - 1500, curretSea.transform.position.y, curretSea.transform.position.z), Quaternion.identity, this.transform);
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x, curretSea.transform.position.y, curretSea.transform.position.z + 1500), Quaternion.identity, this.transform);
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x + 1500, curretSea.transform.position.y, curretSea.transform.position.z), Quaternion.identity, this.transform);
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x + 1500, curretSea.transform.position.y, curretSea.transform.position.z + 1500), Quaternion.identity, this.transform);
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x - 1500, curretSea.transform.position.y, curretSea.transform.position.z - 1500), Quaternion.identity, this.transform);
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x - 1500, curretSea.transform.position.y, curretSea.transform.position.z + 1500), Quaternion.identity, this.transform);
        Instantiate(nextSea, new Vector3(curretSea.transform.position.x + 1500, curretSea.transform.position.y, curretSea.transform.position.z - 1500), Quaternion.identity, this.transform);
        yield return null;
    }
}
