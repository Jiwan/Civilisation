/*!
 * \file BasicSquareRandomizer.h
 * \author J.Guegant 
 * \author R.Lagrange
 * This file contains an implementation of a basic square randomizer.
 */

#ifndef BASICSQUARERANDOMIZER_H
#define BASICSQUARERANDOMIZER_H

#include "Common.h"
#include "ISquareRandomizer.h"

class DECLDIR BasicSquareRandomizer : ISquareRandomizer
{
public:
	/*! \brief Constructor
	 */
	BasicSquareRandomizer() : m_waterRange(10), m_desertRange(35), m_fieldRange(80)
	{

	}

	/*! \brief virtual destructor to avoid memory leaks. 
	 */
	virtual ~BasicSquareRandomizer()
	{

	}
	
	/*! \brief Create a tile type and a decorator type according to an height.
	 */
	virtual std::pair<TileType, DecoratorType> createCase(double value)
	{
		TileType type = TileType::FIELD;

		if (0 <= value && value < m_waterRange)
		{
			type = TileType::WATER;
		} 
		else if (m_waterRange <= value && value < m_desertRange)
		{
			type = TileType::DESERT;
		}
		else if (m_desertRange <= value && value < m_fieldRange)
		{
			type = TileType::FIELD;
		}
		else 
		{
			type = TileType::WATER;
		}

		return std::make_pair(type, getDecorator(type));
	}

	/*! \brief set the water range.
	 *  \param the new range.
	 */
	void setWaterRange(double range)
	{
		m_waterRange = range;
	}

	/*! \brief set the desert range.
	 *  \param the new range.
	 */
	void setDesertRange(double range)
	{
		m_desertRange = range;
	}

	/*! \brief set the field range.
	 *  \param the new range.
	 */
	void setFieldRange(double range)
	{
		m_fieldRange = range;
	}

private:
	DecoratorType getDecorator(TileType& tileType)
	{
		if (tileType == TileType::WATER)
		{
			return DecoratorType::NONE;
		}
		else
		{
			int value = rand() % 6;

			if (value == 0)
			{
				return DecoratorType::FRUIT;
			}
			else if (value == 1)
			{
				return DecoratorType::IRON;
			}
			else
			{
				return DecoratorType::NONE;
			}
		}
	}


private:
	double m_waterRange;
	double m_desertRange;
	double m_fieldRange;
};
#endif