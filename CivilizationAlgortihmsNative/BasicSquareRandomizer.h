#ifndef BASICSQUARERANDOMIZER_H
#define BASICSQUARERANDOMIZER_H

#include "Common.h"
#include "ISquareRandomizer.h"

class DECLDIR BasicSquareRandomizer : ISquareRandomizer
{
public:
	BasicSquareRandomizer() : m_waterRange(10), m_desertRange(35), m_fieldRange(80)
	{

	}

	virtual ~BasicSquareRandomizer()
	{

	}

	virtual std::pair<TileType, DecoratorType> createCase(double value)
	{
		if (0 <= value && value < m_waterRange)
		{
			return std::make_pair(TileType::WATER, DecoratorType::NONE);
		} 
		else if (m_waterRange <= value && value < m_desertRange)
		{
			return std::make_pair(TileType::DESERT, DecoratorType::NONE);
		}
		else if (m_desertRange <= value && value < m_fieldRange)
		{
			return std::make_pair(TileType::FIELD, DecoratorType::NONE);
		}
		else 
		{
			return std::make_pair(TileType::MOUNTAIN, DecoratorType::NONE);
		}
	}

	void setWaterRange(double range)
	{
		m_waterRange = range;
	}

	void setDesertRange(double range)
	{
		m_desertRange = range;
	}

	void setFieldRange(double range)
	{
		m_fieldRange = range;
	}

private:
	double m_waterRange;
	double m_desertRange;
	double m_fieldRange;
};
#endif