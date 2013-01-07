/*!
 * \file CivilizationAlgorithms.cpp
 * \author J.Guegant 
 * \author R.Lagrange
 * This file contains the implementation of a class that handles all entries for our native algorithms.
 */

#include "stdafx.h"

#include "Singleton.h"
#include "PerlinNoise.h"
#include "BasicSquareRandomizer.h"
#include "CivilizationAlgorithms.h"
#include "IdealLocation.h"

#pragma managed

using namespace CivilizationAlgorithms;

typedef Loki::SingletonHolder<PerlinNoiseMap<> > SingletonPerlinNoiseMap;
typedef Loki::SingletonHolder<BasicSquareRandomizer> SingletonBasicSquareRandomizer;
typedef Loki::SingletonHolder<IdealLocation> SingletonIdealLocation;

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

void PerlinNoise::FindIdealPositions()
{
	SingletonIdealLocation::Instance().findIdealPositions(SingletonPerlinNoiseMap::Instance());
}

Position PerlinNoise::GetIdealPosition1()
{
	Coord c = SingletonIdealLocation::Instance().getPosition1();
	return Position(c.first, c.second);
}

Position PerlinNoise::GetIdealPosition2()
{
	Coord c = SingletonIdealLocation::Instance().getPosition2();
	return Position(c.first, c.second);
}

Position PerlinNoise::GetIdealPosition3()
{
	Coord c = SingletonIdealLocation::Instance().getPosition3();
	return Position(c.first, c.second);
}