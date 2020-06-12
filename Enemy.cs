using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float startSpeed = 2f;
	private float speed;

	public float startHealth = 100;
	private float health;

	public int value = 50;

	private bool isDead = false;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		target = Waypoints.points[0];
		health = startHealth;
		speed = startSpeed;
	}

	public void TakeDamage(float damageAmount)
	{
		health -= damageAmount;
		if (health <= 0f && !isDead)
		{
			Die();
		}
	}

	void Die()
	{
		isDead = true;

		PlayerStats.Gold += value;
		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

	void Update()
	{
		Vector2 direction = target.position - transform.position;
		transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

		if (Vector2.Distance(transform.position, target.position) <= 0.2f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}
		wavepointIndex++;

		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		PlayerStats.Lives--;
		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}
}
