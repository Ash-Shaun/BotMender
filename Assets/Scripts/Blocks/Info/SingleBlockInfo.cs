﻿using UnityEngine;

namespace Blocks.Info {
	/// <summary>
	/// Information about a specific block type.
	/// </summary>
	public class SingleBlockInfo : BlockInfo {
		public readonly BlockSides ConnectSides;

		public SingleBlockInfo(BlockType type, uint health, uint mass, GameObject prefab, BlockSides connectSides) :
			base(type, health, mass, prefab) {
			ConnectSides = connectSides;
		}
	}
}
