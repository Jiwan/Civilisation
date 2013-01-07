/*!
 * \file IdealLocation.h
 * \author J.Guegant 
 * \author R.Lagrange
 * This file contains the IdealLocation class.
 */

#ifndef IDEALLOCATION_H
#define IDEALLOCATION_H

#include <vector>
#include <algorithm>

#include "PerlinNoise.h"


typedef std::pair<std::pair<unsigned int, unsigned int>, unsigned int> CoordValue;
typedef std::pair<unsigned int, unsigned int> Coord;

/*! \class IdealLocation
 * \brief Compute ideal locations for new cities.
 *
 * This class compute ideal locations for creating a new city in the current map.
 */
class DECLDIR IdealLocation
{
public:
	/*! \brief Find all ideal positions.
	 *
	 *  \param map : the map you want to find the locations on.
	 *  \param squareSize : the size of the square you want to compute the average weight of a point.
	 */
	void findIdealPositions(PerlinNoiseMap<>& map, unsigned int squareSize = 5)
	{
		std::vector<unsigned int> squareWeightMap(map.getWidth() * map.getHeight());
		
		for (int i = 0; i < map.getHeight(); ++i)
		{
			for (int j = 0; j < map.getWidth(); ++j)
			{
				switch(map.getTileType(j, i))
				{
				case TileType::WATER:
					squareWeightMap[j + i * map.getWidth()] = 0;
					break;
				case TileType::FIELD:
					squareWeightMap[j + i * map.getWidth()] = 5;
					break;
				case TileType::MOUNTAIN:
					squareWeightMap[j + i * map.getWidth()] = 3;
					break;
				case TileType::DESERT:
					squareWeightMap[j + i * map.getWidth()] = 2;
					break;
				}

				switch(map.getDecoratorType(j, i))
				{
				case DecoratorType::FRUIT:
					squareWeightMap[j + i * map.getWidth()] += 2;
					break;

				case DecoratorType::IRON:
					squareWeightMap[j + i * map.getWidth()] += 2;
					break;
				default:
					break;
				}
			}
		}

		std::vector<CoordValue> squareAverageMap(map.getWidth() * map.getHeight());
		Coord point1;
		Coord point2;

		for (unsigned int i = 0; i < map.getHeight(); ++i)
		{
			for (unsigned int j = 0; j < map.getWidth(); ++j)
			{
				squareAverageMap[i * map.getWidth() + j].first.first = j;
				squareAverageMap[i * map.getWidth() + j].first.second = i;

				point1.first = std::max<int>(0, static_cast<int>(i) - static_cast<int>(squareSize));
				point1.second = std::max<int>(0, static_cast<int>(j) - static_cast<int>(squareSize));
				point2.first = std::min<int>(map.getHeight(), static_cast<int>(i) + static_cast<int>(squareSize));
				point2.second = std::min<int>(map.getWidth(), static_cast<int>(j) + static_cast<int>(squareSize));

				for (unsigned int u = point1.first; u < point2.first; ++u)
				{
					for (unsigned int v = point1.second; v < point2.second; ++v)
					{
						squareAverageMap[i * map.getWidth() + j].second += squareWeightMap[u * map.getWidth() + v];
					}
				}
			}
		}

		std::sort(squareAverageMap.begin(), squareAverageMap.end(), 
			[](CoordValue& value1, CoordValue& value2)
		{
			return value1.second > value2.second;
		});

		m_position1 = squareAverageMap[0].first;
		m_position2 = squareAverageMap[1].first;
		m_position3 = squareAverageMap[2].first;
	}

	/*! \brief Accessor for the best position for creating a new city.
	 *
	 *  \return the best position for creating a new city.
	 */
	Coord getPosition1()
	{
		return m_position1;
	}

	/*! \brief Accessor for the second position for creating a new city.
	 *
	 *  \return the second position for creating a new city.
	 */
	Coord getPosition2()
	{
		return m_position2;
	}

	/*! \brief Accessor for the third position for creating a new city.
	 *
	 *  \return the third position for creating a new city.
	 */
	Coord getPosition3()
	{
		return m_position3;
	}

private:
	/*! Best position for creating a new city.*/
	Coord m_position1;
	/*! Second position for creating a new city.*/
	Coord m_position2;
	/*! Third position for creating a new city.*/
	Coord m_position3;
};
#endif