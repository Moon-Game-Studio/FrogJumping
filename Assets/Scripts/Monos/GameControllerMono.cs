using System;
using MoonGames.Game.FrogJump.Controllers;
using MoonGames.Game.FrogJump.Models;
using MoonGames.Game.FrogJump.StaticData;
using UnityEngine;

namespace MoonGames.Game.FrogJump.Monos
{
    public class GameControllerMono : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform mapAnchorPoint;
        public GameObject columnPrefab;
        public float distanceBetweenColumns = 100f;
        public float distanceBetweenFrogs = 100f;
        public GameObject frogPrefab;
        private Map map;
        private MapController mapController;

        private void Start()
        {
            map = new Map(StaticDatas.frogCount, columnPrefab, distanceBetweenColumns, frogPrefab, distanceBetweenFrogs);
            try
            {
                map.InitialiseColumns(transform, mapAnchorPoint.position);
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
            }

            mapController = new MapController(map, distanceBetweenFrogs);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectObject();
            }
        }

        private void SelectObject()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            bool raycast = Physics.Raycast(ray, out RaycastHit hit);
            if (!raycast)
            {
                return;
            }

            GameObject hitObject = hit.transform.gameObject;

            if (!hitObject.TryGetComponent(out ColumnMono columnMono))
            {
                return;
            }

            mapController.Select(columnMono);
        }
    }
}