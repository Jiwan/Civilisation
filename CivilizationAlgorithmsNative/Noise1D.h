#ifndef NOISE1D_H
#define NOISE1D_H

#pragma once
class Noise1D
{
public:
	Noise1D(int t, int p, int n);
	~Noise1D(void);

	double bruit1D(int i);
	double interpolation_cos1D(double a, double b, double x);
	double fonction_bruit1D(double x);
	double bruit_coherent1D(double x, double persistance);

private:
	int pas1D;
	int nombre_octaves1D;
	int taille;
	double* valeurs1D;
};

#endif