using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace SLGLib
{
    [CustomEditor(typeof(SpawnCheckerHelper))]
    public class SpawnCheckerHelperInspector : Editor
    {
        private SpawnCheckerHelper body;

        private void OnEnable()
        {
            body = target as SpawnCheckerHelper;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.BeginVertical();

            body.CheckerStand =
                EditorGUILayout.ObjectField("CheckerStand", body.CheckerStand, typeof(GameObject), true) as GameObject;
            body.Root = EditorGUILayout.ObjectField("Root", body.Root, typeof(Transform), true) as Transform;
            EditorGUILayout.Space();
            body.BoardSize = EditorGUILayout.IntField("BoardSize", body.BoardSize);
            body.CheckerCoordSpace = EditorGUILayout.FloatField("CheckerCoordSpace", body.CheckerCoordSpace);
            EditorGUILayout.Space();
            EditorGUILayout.Space();
            var bSpawnCheckersClicked = GUILayout.Button("SpawnCheckers");
            var bClearCheckersClicked = GUILayout.Button("ClearCheckers");

            EditorGUILayout.EndVertical();

            if (bSpawnCheckersClicked)
            {
                body.SpawnCheckers();
            }

            if (bClearCheckersClicked)
            {
                body.ClearCheckers();
            }
        }
    }
}