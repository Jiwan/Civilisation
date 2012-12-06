// CivilizationAlgorithmsNative.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include "Noise.h"

// On d�finit la taille de l'image.
#define TAILLE 25
// On d�finit le nombre d'octaves.
#define OCTAVES 8
// On d�finit le pas.
#define PAS 128
// On d�finit la persistance.
#define PERSISTANCE 0.8

int _tmain(int argc, _TCHAR* argv[])
{
	Noise();
	Noise::initBruit2D(TAILLE + 1, TAILLE + 1, PAS, OCTAVES);
	double[][] matrix = new double[TAILLE][TAILLE];

	int[TAILLE][TAILLE] matrix;
	for(int i = 0; i < TAILLE; i++) {
		for(int j = 0; j < TAILLE; j++) {
			matrix[i][j] = Noise::bruit_coherent2D(i, j, PERSISTANCE, OCTAVES);
		}
	}

	for(int i = 0; i < TAILLE; i++) {
		for(int j = 0; j < TAILLE; j++) {
			std::cout << "[" + matrix[i][j] + "]";
		}
		std::cout << endl;
	}

	Noise::destroyBruit2D();
	return 0;
}

