using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moves : MonoBehaviour
{
    //[SerializeField]
    //private GameObject Player;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] float Speed;
    [SerializeField] GameObject Laser;
    bool CanFire = false;
    Vector3[] Trajectory;
    Vector3 playerPosition;
    public bool isLoadPlayer;
    bool isInstantiate;

    // Update is called once per frame
    void Update()
    {
        if (isLoadPlayer)
        {
            GetPlayerPosition();
            isLoadPlayer = false;
            isInstantiate = true;
        }

        if(isInstantiate)
        {
            if (Input.touchCount > 0)
            {
                Aim();
            }
            else
            {
                RemoveAim();
                if (CanFire) Fire();
            }
        }        
        
    }
    void Start()
    {
        LineRenderer lineRenderer = Laser.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.startWidth = lineRenderer.endWidth = 0.1f;
        lineRenderer.sortingOrder = 1;      
    }

    void GetPlayerPosition()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    Vector3[] GetTrajectory(Vector3 start, Vector3 direction)
    {
        List<Vector3> points = new List<Vector3>();
        Ray2D ray = new Ray2D(start, direction);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1000);
        bool flag = hit.collider != null;

        points.Add(start);
        var i = 0;
        while (flag && i++ < 300)
        {
            ray = new Ray2D(hit.point, Vector2.Reflect(ray.direction, hit.normal));
            hit = Physics2D.Raycast(ray.origin, ray.direction, 1000);
            flag = hit.collider != null;
            points.Add(ray.origin);
        }
        points.Add(ray.direction + ray.origin);

        return points.ToArray();
    }

    void Aim()
    {
        Vector2 data = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        LineRenderer lineRenderer = Laser.GetComponent<LineRenderer>();
        Vector2 start = SpawnPoint.transform.position;
        CanFire = true;
        Trajectory = GetTrajectory(start, data - start);

        int numPos = (Trajectory.Length >= 3) ? 3 : 2;
        lineRenderer.numPositions = numPos;
        Vector3[] points = new Vector3[numPos];
        Array.Copy(Trajectory, points, numPos);
        lineRenderer.SetPositions(points);


    }

    void RemoveAim()
    {
        LineRenderer lineRenderer = Laser.GetComponent<LineRenderer>();
        lineRenderer.numPositions = 0;
    }

    void Fire()
    {
        GenerateBullet();
        CanFire = false;
    }

    void GenerateBullet()
    {
        Vector2 bulletPosition = SpawnPoint.transform.position;
        GameObject createdBullet = Instantiate(Bullet, bulletPosition, transform.rotation) as GameObject;
        var coroutine = StartCoroutine(MoveObjectAlongTrajectiory(createdBullet, Trajectory));
        //StartCoroutine(DissipateBullet(createdBullet, coroutine));

    }

    IEnumerator DissipateBullet(GameObject bullet, Coroutine coroutine)
    {
        yield return new WaitForSeconds(1f);
        //StopCoroutine(coroutine);
        Destroy(bullet);

    }

    IEnumerator MoveObjectAlongTrajectiory(GameObject obj, Vector3[] trajectory)
    {
        int i = 1;
        while (i < trajectory.Length)
        {
            //bullet.transform.position = Vector2.MoveTowards(
            //    trajectory[i - 1], trajectory[i], Speed*Time.deltaTime);
            yield return StartCoroutine(MoveObjectToPoint(obj, trajectory[i]));
            i++;
        }
        Vector2 direction = trajectory[trajectory.Length - 1] - trajectory[trajectory.Length - 2];
        StartCoroutine(MoveObjectToPoint(obj, direction + (Vector2)obj.transform.position, true));

    }

    IEnumerator MoveObjectToPoint(GameObject obj, Vector2 point, bool infinity = false)
    {
        var direction = (infinity) ? point - (Vector2)obj.transform.position: new Vector2(0, 0);
        while ((Vector2)obj.transform.position != point || infinity)
        {
            var p = (infinity) ? (Vector2)obj.transform.position : point;
            obj.transform.position = Vector2.MoveTowards(
                obj.transform.position, p + direction, Speed*Time.deltaTime
                );
            yield return null;
        }
    }
}
