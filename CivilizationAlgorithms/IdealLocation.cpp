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

bool sup (int i, int j)
{
	return (i > j);
}

IdealLocation::IdealLocation(std::unique_ptr<std::pair<TileType, DecoratorType>[]> map, unsigned int width, unsigned int height)
{
	std::cout << "IdealLocation.\n";

	m_width = width;
	m_height = height;
	m_mapValeurs = new unsigned int[m_width * m_height];
	std::cout << "Initial declarations finished.\n";

	// convertir map en map de "valeur" de chaque case
	for (int i = 0; i < m_height; i++)
	{
		for (int j = 0; j < m_width; j++)
		{
			int valeurTileType = 0;
			int valeurDecoratorType = 0;

			switch (map[i * width + j].first)
			{
				case WATER:
					valeurTileType = 0;
					break;
				case MOUNTAIN:
					valeurTileType = 3;
					break;
				case FIELD:
					valeurTileType = 5;
					break;
				case DESERT:
					valeurTileType = 2;
					break;
			}
			std::cout << "Switch valeurTileType de la case (" << i << ", " << j << ") terminé.\n";

			switch (map[i * width + j].second)
			{
				case NONE:
					valeurDecoratorType = 0;
					break;
				case FRUIT:
					valeurDecoratorType = 2;
					break;
				case IRON:
					valeurDecoratorType = 2;
					break;
			}

			std::cout << "Switch valeurDecoratorType de la case (" << i << ", " << j << ") terminé.\n";

			m_mapValeurs[i * width + j] = valeurTileType + valeurDecoratorType;
		}
	}
}

IdealLocation::~IdealLocation(void)
{
	delete[] m_mapValeurs;
	delete[] m_mapAlgo;

	std::cout << "Instance détruite.\n";
}

void IdealLocation::calculateValueMap(unsigned int tailleCarre)
{
	std::cout << "calculateValueMap.\n";

	// 2 points pour le calcul de la valeur de la zone
	std::pair<unsigned int, unsigned int>* point1 = new std::pair<unsigned int, unsigned int>;
	std::pair<unsigned int, unsigned int>* point2 = new std::pair<unsigned int, unsigned int>;
	std::cout << "Points déclarés.\n";

	// Déclaration de m_mapAlgo de taille m_width * m_height
	m_mapAlgo = new unsigned int[m_width * m_height];
	std::cout << "m_mapAlgo déclarée.\n";

	for (int i = 0; i < m_height; i++)
	{
		for (int j = 0; j < m_width; j++)
		{
			//Etape 1 : Calcul des 2 points (HautGauche et BasDroite) du carré de calcul
			point1->first = i;
			point1->second = j;
			point2->first = i;
			point2->second = j;

			unsigned int carre = 0;
			while (point1->first >= 0 && carre < tailleCarre)
			{
				point1->first--;
				carre++;
			}

			carre = 0;
			while (point1->second >= 0 && carre < tailleCarre)
			{
				point1->second--;
				carre++;
			}

			carre = 0;
			while (point2->first < m_height && carre < tailleCarre)
			{
				point2->first++;
				carre++;
			}

			carre = 0;
			while (point2->second < m_width && carre < tailleCarre)
			{
				point2->second++;
				carre++;
			}

			std::cout << "Calcul des points du carré de la case (" << i << ", " << j << ") terminé.\n";

			//Etape 2 : sommer les valeurs compris dans ce carré
			for (int x = point1->first; x < point2->first; x++)
			{
				for (int y = point1->first; y < point2->second; y++)
				{
					m_mapAlgo[i * m_width + j] += m_mapValeurs[x * m_width + y];
				}
			}
			std::cout << "Calcul de la valeur de la case (" << i << ", " << j << ") terminé.\n";
		}
	}
	std::cout << "calculateValueMap finished.\n";
}

void IdealLocation::findIdealPositions()
{
	// m_mapAlgo completée. Plus qu'à choisir les nbValeurs points avec la plus grande valeur.
	std::vector<unsigned int>* vectorAlgo = new std::vector<unsigned int>(m_mapAlgo, m_mapAlgo + (m_width * m_height));
	std::vector<unsigned int>::iterator iterator;
	
	//trouver les nbValeurs maximales
	sort (vectorAlgo->begin(), vectorAlgo->end(), sup);

	int index1, index2, index3 = 0;

	for (int i = 0; i < m_width * m_height; ++i)
	{
		if (m_mapAlgo[i] == vectorAlgo->at(0))
			index1 = i;
		if (m_mapAlgo[i] == vectorAlgo->at(1))
			index2 = i;
		if (m_mapAlgo[i] == vectorAlgo->at(2))
			index3 = i;
	}

	m_position1 = new std::pair<unsigned int, unsigned int>(static_cast<unsigned int>(index1 / m_width), static_cast<unsigned int>((index1 % m_width) - 1));
	m_position2 = new std::pair<unsigned int, unsigned int>(static_cast<unsigned int>(index2 / m_width), static_cast<unsigned int>((index2 % m_width) - 1));
	m_position3 = new std::pair<unsigned int, unsigned int>(static_cast<unsigned int>(index3 / m_width), static_cast<unsigned int>((index3 % m_width) - 1));
}