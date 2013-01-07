#ifndef IDEALLOCATION_H
#define IDEALLOCATION_H
#include "PerlinNoise.h"
class IdealLocation
{
public:
	IdealLocation(PerlinNoiseMap<>& map) : m_map(map)
	{

	}

	void findIdealPositions()
	{

	}

	std::pair<unsigned int, unsigned int> getPosition1()
	{
		return m_position1;
	}

	std::pair<unsigned int, unsigned int> getPosition2()
	{
		return m_position2;
	}

	std::pair<unsigned int, unsigned int> getPosition3()
	{
		return m_position3;
	}
private:
	PerlinNoiseMap<>& m_map;
	std::pair<unsigned int, unsigned int> m_position1;
	std::pair<unsigned int, unsigned int> m_position2;
	std::pair<unsigned int, unsigned int> m_position3;
};
#endif