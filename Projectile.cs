using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Transform target;

	[Header("General Attributes")]
	public float speed = 70f;
	public float damage = 50f;

	[Header("Special Attributes")]
	public float explosionRadius = 0f;
	public float slowRate = 0f;
	private float slowDuration = 1f;
	private float slowCountdown = 0f;
	public bool isSlowing = false;

	public void SeekTarget(Transform _target)
	{
		target = _target;
	}

	void Update()
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 direction = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (direction.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(direction.normalized * distanceThisFrame, Space.World);
		//transform.LookAt(target);

		float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
	}

	void HitTarget()
	{
		Damage(target);
		Destroy(gameObject);
	}

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		if (e != null)
		{
			e.TakeDamage(damage);
		}
	}

	void OnDrawGizmoSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
