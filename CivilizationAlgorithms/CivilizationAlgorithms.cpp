// Il s'agit du fichier DLL principal.

#include "stdafx.h"

#include "Singleton.h"
#include "PerlinNoise.h"
#include "BasicSquareRandomizer.h"
#include "CivilizationAlgorithms.h"

#pragma managed

using namespace CivilizationAlgorithms;

typedef Loki::SingletonHolder<PerlinNoiseMap<> > SingletonPerlinNoiseMap;
typedef Loki::SingletonHolder<BasicSquareRandomizer> SingletonBasicSquareRandomizer;

void PerlinNoise::GenerateHeightMap(double maxHeight, unsigned int width, unsigned int height)
{
	BasicSquareRandomizer& randomizer = SingletonBasicSquareRandomizer::Instance();
	SingletonPerlinNoiseMap::Instance().generateHeightMap(reinterpret_cast<ISquareRandomizer*>(&randomizer), maxHeight, width, height);
}

ManagedTileType PerlinNoise::GetTileType(int x, int y)
{
	return static_cast<ManagedTileType>(SingletonPerlinNoiseMap::Instance().getTileType(x, y));
}

ManagedDecoratorType PerlinNoise::GetDecoratorType(int x, int y)
{
	return static_cast<ManagedDecoratorType>(SingletonPerlinNoiseMap::Instance().getDecoratorType(x, y));
}

void PerlinNoise::UpdateQuantities(double water, double desert, double field)
{
	SingletonBasicSquareRandomizer::Instance().setWaterRange(water);
	SingletonBasicSquareRandomizer::Instance().setDesertRange(desert);
	SingletonBasicSquareRandomizer::Instance().setFieldRange(field);
}