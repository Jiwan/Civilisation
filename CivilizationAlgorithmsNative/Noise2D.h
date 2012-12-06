#ifndef NOISE2D_H
#define NOISE2D_H

#pragma once
class Noise2D
{
public:
	Noise2D(int longueur, int hauteur, int pas, int octaves);
	~Noise2D(void);
	void initBruit1D(int longueur, int pas, int octaves);
	double bruit_coherent1D(double x, double persistance);
	void destroyBruit1D();

	
	double bruit_coherent2D(double x, double y, double persistance);

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