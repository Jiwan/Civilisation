#ifndef BASICSQUARERANDOMIZER_H
#define BASICSQUARERANDOMIZER_H

#include "Common.h"
#include "ISquareRandomizer.h"

class BasicSquareRandomizer : ISquareRandomizer
{
public:
	virtual ~BasicSquareRandomizer()
	{

	}

	virtual std::pair<TileType, DecoratorType> createCase(double value)
	{
		if (0 <= value && value < 10)
		{
			return std::make_pair(TileType::WATER, DecoratorType::NONE);
		} 
		else if (10 <= value && value < 35)
		{
			return std::make_pair(TileType::DESERT, DecoratorType::NONE);
		}
		else if (35 <= value && value < 80)
		{
			return std::make_pair(TileType::FIELD, DecoratorType::NONE);
		}
		else 
		{
			return std::make_pair(TileType::MOUNTAIN, DecoratorType::NONE);
		}
	}
};
#endif