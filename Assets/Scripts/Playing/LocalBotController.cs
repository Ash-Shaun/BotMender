﻿using Assets.Scripts.Structures;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Playing {
	/// <summary>
	/// Gives the player controls over the structure it is attached to, should be used in play mode.
	/// </summary>
	public class LocalBotController : MonoBehaviour {
		private Camera _camera;
		private CompleteStructure _structure;

		[UsedImplicitly]
		public void Awake() {
			_camera = Camera.main;
			_structure = GetComponent<CompleteStructure>();
		}



		[UsedImplicitly]
		public void Update() {
			if (Input.GetButtonDown("Ability")) {
				_structure.UseActive();
			}
		}

		[UsedImplicitly]
		public void FixedUpdate() {
			if (!Input.GetButton("FreeLook")) {
				Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit)) {
					_structure.TrackTarget(hit.point);
				} else {
					_structure.TrackTarget(ray.origin + ray.direction * 500);
				}
			}

			if (Input.GetButton("Fire1")) {
				_structure.FireWeapons();
			}

			Vector3 newMoveRotateInput = new Vector3(
				Input.GetAxisRaw("Rightward"),
				Input.GetAxisRaw("Upward"),
				Input.GetAxisRaw("Forward")
			);

			if (!newMoveRotateInput.Equals(_structure.MoveRotateDirection)) {
				_structure.SetMoveRotateDirection(newMoveRotateInput);
			}
		}
	}
}