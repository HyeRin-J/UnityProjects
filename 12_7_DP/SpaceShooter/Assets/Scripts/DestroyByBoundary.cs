using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
