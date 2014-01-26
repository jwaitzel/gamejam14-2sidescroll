using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InfiniteScrolling : MonoBehaviour {

	public Camera selectedCamera;
	private List<Transform> backgroundPart;
	// Use this for initialization
	void Start () {
		
		backgroundPart = new List<Transform>();
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			if (child.renderer != null)
			{
				backgroundPart.Add(child);
			}
		}
		
		backgroundPart = backgroundPart.OrderBy(
			t => -t.position.x
			).ToList();
	}
	
	// Update is called once per frame
	void Update () {
	
		Transform firstChild = backgroundPart.FirstOrDefault();
		if (firstChild != null)
		{
			// Check if the child is already (partly) before the camera.
			// We test the position first because the IsVisibleFrom
			// method is a bit heavier to execute.
			if (firstChild.position.x > selectedCamera.transform.position.x)
			{
				// If the child is already on the left of the camera,
				// we test if it's completely outside and needs to be
				// recycled.
				if (firstChild.renderer.IsVisibleFrom(selectedCamera) == false)
				{
					// Get the last child position.
					Transform lastChild = backgroundPart.LastOrDefault();
					Vector3 lastPosition = lastChild.transform.position;
					Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
					
					// Set the position of the recyled one to be AFTER
					// the last child.
					// Note: Only work for horizontal scrolling currently.
					firstChild.position = new Vector3(lastPosition.x - lastSize.x, firstChild.position.y, firstChild.position.z);
					
					// Set the recycled child to the last position
					// of the backgroundPart list.
					backgroundPart.Remove(firstChild);
					backgroundPart.Add(firstChild);
				}
			}
		}
	}
}
