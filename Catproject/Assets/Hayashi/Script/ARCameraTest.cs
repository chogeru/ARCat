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
        // ���ʂ��ǉ��܂��͍X�V���ꂽ�ꍇ�A�ŏ��̕��ʂ��i�r�Q�[�V�������b�V���ɕϊ����ĖڕW�n�_�ɐݒ肷��
        if (eventArgs.added != null && eventArgs.added.Count > 0)
        {
            ARPlane plane = eventArgs.added[0];
            if (plane.boundary.Length >= 3)
            {
                // ���ʂ̒��_���i�r�Q�[�V�������b�V���̍��W�ɕϊ�
                List<Vector3> vertices = new List<Vector3>();
                foreach (Vector3 vertex in plane.boundary)
                {
                    Vector3 worldPos = plane.transform.TransformPoint(vertex);
                    vertices.Add(worldPos);
                }

                // �i�r�Q�[�V�������b�V���̐����ƖڕW�n�_�̐ݒ�
                NavMeshBuildSettings buildSettings = NavMesh.GetSettingsByID(0);
                NavMeshData navMeshData = NavMeshBuilder.BuildNavMeshData(buildSettings, new List<NavMeshBuildSource>(), new Bounds(Vector3.zero, Vector3.one), Vector3.zero, Quaternion.identity);
                NavMesh.RemoveAllNavMeshData();
                NavMesh.AddNavMeshData(navMeshData);
                navAgent.SetDestination(vertices[0]);
            }
        }
    }
}

