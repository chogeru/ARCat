using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.AI;

public class ARCameraTest : MonoBehaviour
{
    private ARPlaneManager planeManager;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        // 平面が追加または更新された場合、最初の平面をナビゲーションメッシュに変換して目標地点に設定する
        if (eventArgs.added != null && eventArgs.added.Count > 0)
        {
            ARPlane plane = eventArgs.added[0];
            if (plane.boundary.Length >= 3)
            {
                // 平面の頂点をナビゲーションメッシュの座標に変換
                List<Vector3> vertices = new List<Vector3>();
                foreach (Vector3 vertex in plane.boundary)
                {
                    Vector3 worldPos = plane.transform.TransformPoint(vertex);
                    vertices.Add(worldPos);
                }

                // ナビゲーションメッシュの生成と目標地点の設定
                NavMeshBuildSettings buildSettings = NavMesh.GetSettingsByID(0);
                NavMeshData navMeshData = NavMeshBuilder.BuildNavMeshData(buildSettings, new List<NavMeshBuildSource>(), new Bounds(Vector3.zero, Vector3.one), Vector3.zero, Quaternion.identity);
                NavMesh.RemoveAllNavMeshData();
                NavMesh.AddNavMeshData(navMeshData);
                navAgent.SetDestination(vertices[0]);
            }
        }
    }
}

