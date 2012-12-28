// CivilizationAlgorithms.h

#pragma once
#pragma managed

using namespace System;

namespace CivilizationAlgorithms {

	public enum class ManagedTileType
	{
		Water = 0,
		Desert = 1,
		Field = 2,
		Mountain = 3,
	};

	public enum class ManagedDecoratorType {
		None = 0,
		Fruit = 1,
		Iron = 2,
	};

	public ref class PerlinNoise sealed
	{
	public:
		static void GenerateHeightMap(double maxHeight, unsigned int width, unsigned int height);
		static ManagedTileType GetTileType(int x, int y);
		static ManagedDecoratorType GetDecoratorType(int x, int y);
	};
}
