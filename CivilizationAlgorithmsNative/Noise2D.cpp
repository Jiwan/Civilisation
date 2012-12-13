#include "StdAfx.h"
#include "Noise2D.h"
#include "Noise1D.h"
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <stdio.h>

enum TerrainType { WATER, WATER, WATER, WATER, DESERT, FIELD, MOUNTAIN, MOUNTAIN, MOUNTAIN, MOUNTAIN };
const int rand_max = 9;
const double pi = 3.14159265;

Noise2D::Noise2D(int l, int h, int p, int n) {
	nombre_octaves2D = n;
    longueur = l;
    hauteur = h;
    pas2D = p;

    int longueur_max = static_cast<int>(ceil(longueur * pow(2.0, (nombre_octaves2D - 1) / pas2D)));
    int hauteur_max = static_cast<int>(ceil(hauteur * pow(2.0, (nombre_octaves2D - 1) / pas2D)));
    
	if(valeurs2D != 0)
	{
		for(int i = 0; i < longueur_max; i++)
		{
			delete[] valeurs2D[i];
		}
		delete[] valeurs2D;
	}
    
	valeurs2D = new double[longueur_max][hauteur_max];

    srand(time(NULL));
    for(int i = 0; i < longueur_max; i++) 
	{
		for(int j = 0; j < hauteur_max; j++)
		{
			valeurs2D[i][j] = static_cast<double>((rand()) / rand_max);
		}
	}
}

Noise2D::~Noise2D() {
	for(int i = 0; i < longueur_max; i++)
	{
		delete[] valeurs2D[i];
	}
	delete[] valeurs2D;
    longueur = 0;
}

double Noise2D::getVal(int i, int j) {
    return valeurs2D[i][j];
}

double Noise2D::interpolation_cos2D(double a, double b, double c, double d, double x, double y) {
   double y1 = Noise1D::interpolation_cos1D(a, b, x);
   double y2 = Noise1D::interpolation_cos1D(c, d, x);
   return  Noise1D::interpolation_cos1D(y1, y2, y);
}

double Noise2D::fonction_bruit2D(double x, double y) {
   int i = (int) (x / pas2D);
   int j = (int) (y / pas2D);
   return interpolation_cos2D(getVal(i, j), getVal(i + 1, j), getVal(i, j + 1), getVal(i + 1, j + 1), fmod(x / pas2D, 1), fmod(y / pas2D, 1));
}

double Noise2D::bruit_coherent2D(double x, double y, double persistance) {
    double somme = 0;
    double p = 1;
    int f = 1;
    int i;

    for(i = 0 ; i < nombre_octaves2D ; i++)
	{
        somme += p * fonction_bruit2D(x * f, y * f);
        p *= persistance;
        f *= 2;
    }
    return somme * (1 - persistance) / (1 - p);
}

double Noise2D::obtenirPixel(int x, int y, double persistance) {
    double valeur = bruit_coherent2D(x, y, persistance);
	return valeur;
}