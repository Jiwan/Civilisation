/*!
 * \file PerlinNoise.h
 * \author J.Guegant 
 * \author R.Lagrange
 * This file contains the perlin noise class and its policies.
 */

#ifndef PERLINNOISE_H
#define PERLINNOISE_H
#define _USE_MATH_DEFINES

#include <math.h>
#include <stdlib.h>
#include <time.h>
#include <memory>
#include <algorithm>
#include <iostream>
 
#include "Common.h"
#include "ISquareRandomizer.h"

/*! \struct LinearInterpolation
 *  \brief Linear interpolation policy for the PerlinNoiseMap class.
 */
struct DECLDIR LinearInterpolation
{
public:
	virtual double interpolate(double a, double b, double c, double d, double x, double y)
	{
		double i1 = interpolateBase(a, b, x);
		double i2 = interpolateBase(c, d, x);

		return interpolateBase(i1, i2, y);
	}

protected:
	virtual double interpolateBase(double a, double b, double x)
	{
		return a + ((b - a) * x);
	}
};

/*! \struct LinearInterpolation
 *  \brief Cosinus interpolation policy for the PerlinNoiseMap class.
 */
struct DECLDIR CosInterpolation : LinearInterpolation
{
private:
	virtual double interpolateBase(double a, double b, double x)
	{
		double k = (1 - cos(x * M_PI)) / 2;

		return LinearInterpolation::interpolateBase(a, b, k);
	}
};


/*! \class PerlinNoiseMap
 *  Create a pseudo-random map according to user's needs.
 *  As we don't need to change interpolation type at runtime, we use policy (better at compile-time).
 */
template <class InterpolationPolicy = CosInterpolation> class DECLDIR PerlinNoiseMap : InterpolationPolicy
{
public:
	/*! \brief Constructor
	 */
	PerlinNoiseMap()
	{
		srand(time(NULL));
	}
	/*! \brief generate new map (heightmaps).
	*
	* \param randomizer : the randomizer you want to use to create new tiles.
	* \param maxHeight : the max height for mountain.
	* \param width : the width of the new map.
	* \param height : the height of the new map.
	*/
	void generateHeightMap(ISquareRandomizer* randomizer, double maxHeight, unsigned int width, unsigned int height)
	{
		m_width = width;
		m_height = height;

		m_map = std::unique_ptr<std::pair<TileType, DecoratorType>[]>(new std::pair<TileType, DecoratorType>[width * height]);

		double power = maxHeight;
		unsigned int stepWidth = m_width / 2;
		unsigned int stepHeight = m_height / 2;

		std::unique_ptr<double[]> heightMap(new double[m_width * m_height]);

		memset(heightMap.get(), 0.0f, sizeof(double) * m_width * m_height);

		while (stepWidth > 1 && stepHeight > 1 && power > 1)
		{
			unsigned int sizeWidth = ceil((m_width / static_cast<float>(stepWidth)) + 1);
			unsigned int sizeHeight = ceil((m_width / static_cast<float>(stepHeight)) + 1);

			std::unique_ptr<double[]> randomMatrix(new double[sizeWidth * sizeHeight]);

			for (unsigned int i = 0; i < sizeWidth * sizeHeight; ++i)
			{
				randomMatrix[i] = rand() % static_cast<int>(power);
			}

			for (unsigned int i = 0; i < m_width; ++i)
			{
				for (unsigned int j = 0; j < m_height; ++j)
				{
					double edge1 = randomMatrix[(i / stepWidth) + ((j / stepHeight) * sizeWidth)];
					double edge2 = randomMatrix[((i / stepWidth) + 1) + ((j / stepHeight) * sizeWidth)];
					double edge3 = randomMatrix[(i / stepWidth) + (((j / stepHeight) + 1) * sizeWidth)];
					double edge4 = randomMatrix[((i / stepWidth) + 1) + (((j / stepHeight) + 1) * sizeWidth)];
					
					double tmp;
					double posx = modf(i / static_cast<float>(stepWidth), &tmp);
					double posy = modf(j / static_cast<float>(stepHeight), &tmp);

					double value = InterpolationPolicy::interpolate(edge1, edge2, edge3, edge4, posx, posy);

					heightMap[i + (j * m_width)] += value;
				}
			}

			power = log(power); // Try to make a logarithmic decrease.
			stepWidth = stepWidth / 2;
			stepHeight = stepHeight / 2;
		}

		for (unsigned int i = 0; i < m_width; ++i)
		{
			for (unsigned int j = 0; j < m_height; ++j)
			{
				m_map[i + (j * m_width)] = randomizer->createCase(std::min<double>(heightMap[i + (j * m_width)], maxHeight));
			}
		}
	}

	/*! \brief get a the tile type at a given position.
	*   \param x : the x coordinate.
	*   \param y : the y coordinate.
	*   \return the tile type at the given position.
	*/
	TileType getTileType(int x, int y) const
	{
		return m_map[(y * m_width) + x].first;
	}

	/*! \brief get a the decorator type at a given position.
	*   \param x : the x coordinate.
	*   \param y : the y coordinate.
	*   \return the decorator type at the given position.
	*/
	DecoratorType getDecoratorType(int x, int y) const
	{
		return m_map[(y * m_width) + x].second;
	}

	/*! \return the width of the current map.
	*/
	unsigned int getWidth()
	{
		return m_width;
	}

	/*! \return the height of the current map.
	*/
	unsigned int getHeight()
	{
		return m_height;
	}

private:
	std::unique_ptr<std::pair<TileType, DecoratorType>[]> m_map;
	unsigned int m_width;
	unsigned int m_height;
};
#endif
