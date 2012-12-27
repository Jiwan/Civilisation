#ifndef PERLINNOISE_H
#define PERLINNOISE_H

#define _USE_MATH_DEFINES // A mettre dans une 

#include <math.h>
#include <stdlib.h>
#include <time.h>
#include <memory>
#include <algorithm>
#include <iostream>
 
#include "Common.h"
#include "ISquareRandomizer.h"

struct LinearInterpolation
{
	// If we store a field, remember to add a virtual destructor.
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

struct CosInterpolation : LinearInterpolation
{
private:
	virtual double interpolateBase(double a, double b, double x)
	{
		double k = (1 - cos(x * M_PI)) / 2;

		return LinearInterpolation::interpolateBase(a, b, k);
	}
};

// Unlike interpolation, we may want to change the randomizer at running time and not at compile time with a policy.

template <class InterpolationPolicy = CosInterpolation> class PerlinNoiseMap : InterpolationPolicy
{
public:
	PerlinNoiseMap(unsigned int width, unsigned int height) : m_width(width), m_height(height)
	{
		srand(time(NULL));

		m_map = std::unique_ptr<std::pair<TileType, DecoratorType>[]>(new std::pair<TileType, DecoratorType>[width * height]);
	}

	void generateHeightMap(ISquareRandomizer* randomizer, double maxHeight)
	{
		double power = maxHeight;
		unsigned int stepWidth = m_width;
		unsigned int stepHeight = m_height;

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

			power = log(power); // Try to make an logarithmic decrease.
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

	TileType getTileType(int x, int y) const
	{
		return m_map[(y * m_width) + x].first;
	}

	DecoratorType getDecoratorType(int x, int y) const
	{
		return m_map[(y * m_width) + x].second;
	}

	friend std::ostream& operator<<(std::ostream& other, PerlinNoiseMap& map);
private:
	std::unique_ptr<std::pair<TileType, DecoratorType>[]> m_map;
	unsigned int m_width;
	unsigned int m_height;
};

std::ostream& operator<<(std::ostream& out, PerlinNoiseMap<>& map)
{	
	for (unsigned int i = 0; i < map.m_width; ++i)
	{
		for (unsigned int j = 0; j < map.m_height; ++j)
		{
			std::cout << map.getTileType(i, j);
		}

		std::cout << std::endl;
	}

	return out;
}
#endif
