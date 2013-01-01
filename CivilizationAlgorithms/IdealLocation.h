#ifndef IDEALLOCATION_H
#define IDEALLOCATION_H

#include <stdlib.h>
#include <time.h>
#include <memory>
#include <algorithm>
#include <iostream>
#include <vector>
#include <utility>

#include "StdAfx.h"
#include "IdealLocation.h"
#include "CivilizationAlgorithms.h"
#include "Common.h"


#pragma once
ref class IdealLocation
{
private:
	// Les trois positions conseillées
	std::pair<unsigned int, unsigned int>* m_position1;
	std::pair<unsigned int, unsigned int>* m_position2;
	std::pair<unsigned int, unsigned int>* m_position3;

	// Dimensions de la map
	int m_width;
	int m_height;

	// 2 points permettant le calcul de la "valeur" de la case
	typedef std::pair<unsigned int, unsigned int> m_point1;
	typedef std::pair<unsigned int, unsigned int> m_point2;

	// Map avec les cases représentées par des valeurs [0 - 10]: 0 pas de ressources, 10 beaucoup
	unsigned int* m_mapValeurs;
	
	// Map avec la valeur totale du potentiel de chaque case (Avec 8 cases alentours)
	unsigned int* m_mapAlgo;

public:
	IdealLocation(std::unique_ptr<std::pair<TileType, DecoratorType>[]> map, unsigned int width, unsigned int height);
	~IdealLocation(void);

	void calculateValueMap(unsigned int tailleCarre);
	void findIdealPositions();
};

#endif
