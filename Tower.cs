using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	BuildManager buildManager;

	private Transform target;

	[Header("Generals")]
	public float range = 15f;

	[Header("Projectile")]
	public GameObject arrowPrefab;
	public float fireRate = 1f;//Saniyede 1 ateş edecek.
	private float fireCountdown = 0f;//Sayaç. 0 olduğunda ateş edeceğiz.

	[Header("Unity Setup Fields")]
	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public Transform firePoint;
	public Vector3 firePointOffset;

	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget()
	{
		//Düşmanları arraye attık.
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

		float shortestDistance = Mathf.Infinity;//Default olarak düşmanla aradaki değer sonsuz uzaklıkta dedik.
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		//Bir düşman var ve bu range'imiz içinde ise
		if (nearestEnemy != null && shortestDistance <= range)
			target = nearestEnemy.transform;
		else
			target = null;
	}

	void Update()
	{
		//target yoksa kodları çalıştırma.
		if (target == null)
			return;

		LockOnTarget();

		if (fireCountdown <= 0f)//Ateşe hazırsa
		{
			Shoot();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;//Her saniye sayacı 1 azalt.
	}

	void LockOnTarget()
	{
		//Aradaki mesafenin koordinatı
		Vector2 direction = target.position - transform.position;
		//Aradaki mesafenin rotasyon değeri
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		//target rotasyonu ile tower rotasyonunu eşitle
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		//turret rotasyonunu sadece y ekseninde yaptık.
		
		partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
	}

	void Shoot()
	{
		GameObject arrowGameObject = Instantiate(arrowPrefab, firePoint.position + firePointOffset, firePoint.rotation);
		Projectile projectile = arrowGameObject.GetComponent<Projectile>();

		if (projectile != null)
		{
			projectile.SeekTarget(target);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
