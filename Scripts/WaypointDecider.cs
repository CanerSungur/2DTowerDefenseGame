using UnityEngine;

public class WaypointDecider : MonoBehaviour
{
	public WaveSpawner waveSpawner;

	public GameObject waypoint1;
	public GameObject waypoint2;
	public GameObject waypoint3;

	public GameObject waypoint2RoadBlock;
	public GameObject waypoint3RoadBlock;

	public GameObject explosionEffect;

	public void DecideWaypoint()
	{
		int randomWaypoint = 0;

		if (PlayerStats.Rounds >= 5)
		{
			if (waypoint2RoadBlock != null)
			{
				GameObject effect1 = Instantiate(explosionEffect, waypoint2RoadBlock.transform.position, waypoint2RoadBlock.transform.rotation);
				Destroy(effect1, .6f);

				Destroy(waypoint2RoadBlock, .6f);
			}
			randomWaypoint = Random.Range(0, 2);
		}
		if (PlayerStats.Rounds >= 10)
		{
			if (waypoint3RoadBlock != null)
			{
				GameObject effect2 = Instantiate(explosionEffect, waypoint3RoadBlock.transform.position, waypoint3RoadBlock.transform.rotation);
				Destroy(effect2, .6f);

				Destroy(waypoint3RoadBlock, .6f);
			}
			randomWaypoint = Random.Range(0, 3);
		}

		if (randomWaypoint == 0)
		{
			waypoint1.SetActive(true);
			waypoint2.SetActive(false);
			waypoint3.SetActive(false);

			Debug.Log("1. WAYPOINT SECILDI");
		}
		if (randomWaypoint == 1)
		{
			waypoint1.SetActive(false);
			waypoint2.SetActive(true);
			waypoint3.SetActive(false);

			Debug.Log("2. WAYPOINT SECILDI");
		}
		if (randomWaypoint == 2)
		{
			waypoint1.SetActive(false);
			waypoint2.SetActive(false);
			waypoint3.SetActive(true);

			Debug.Log("3. WAYPOINT SECILDI");
		}

		waveSpawner.spawnPoint = Waypoints.points[0].transform;
	}
}
