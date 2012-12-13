#ifndef NOISE2D_H
#define NOISE2D_H

#pragma once
class Noise2D
{
public:
	Noise2D(int longueur, int hauteur, int pas, int octaves);
	~Noise2D();

	double getVal(int i, int j);
	double interpolation_cos2D(double a, double b, double c, double d, double x, double y);
	double fonction_bruit2D(double x, double y);
	double bruit_coherent2D(double x, double y, double persistance);
	double obtenirPixel(int x, int y, double persistance);

private:
	int nombre_octaves2D;
    int longueur;
    int longueur_max;
	int hauteur;
	int hauteur_max;
    int pas2D;
	double** valeurs2D;
};
#endif