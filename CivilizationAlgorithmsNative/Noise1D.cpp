#include "StdAfx.h"
#include "Noise1D.h"
#include <stdlib.h>
#include <math.h>
#include <time.h>
#include <stdio.h>

const double pi = 3.14159265;

Noise1D::Noise1D(int t, int p, int n)
{
    nombre_octaves1D = n;
    //if(taille != 0)
    //    free(valeurs1D);
	if(taille != 0)
	{
		delete valeurs1D;
	}
	taille = t;
    pas1D = p;

    // valeurs1D = (double*) malloc(sizeof(double) * (int) ceil(taille * pow(2, nombre_octaves1D  - 1)  / pas1D));
	int size = ceil(taille * pow(2.0, nombre_octaves1D - 1) / pas1D);
	valeurs1D = new double[size];

    srand(time(NULL));
    int i;
    for(i = 0; i < ceil(taille *  pow(2.0, nombre_octaves1D  - 1)  / pas1D); i++)
	{
        valeurs1D[i] = static_cast<double>(rand() / RAND_MAX);
	}
}

Noise1D::~Noise1D(void)
{
    //if(taille != 0)
    //    free(valeurs1D);
	if(taille != 0)
	{
		delete valeurs1D;
	}
    taille = 0;
}

double Noise1D::bruit1D(int i)
{
    return valeurs1D[i];
}

double Noise1D::interpolation_cos1D(double a, double b, double x)
{
   double k = (1 - cos(x * pi)) / 2;
   return a * (1 - k) + b * k;
}

double Noise1D::fonction_bruit1D(double x)
{
   int i = static_cast<int> (x / pas1D);
   return interpolation_cos1D(bruit1D(i), bruit1D(i + 1), fmod(x / pas1D, 1));
}

double Noise1D::bruit_coherent1D(double x, double persistance)
{
    double somme = 0;
    double p = 1;
    int f = 1;
    int i;

    for(i = 0 ; i < nombre_octaves1D ; i++)
	{
        somme += p * fonction_bruit1D(x * f);
        p *= persistance;
        f *= 2;
    }
    return somme * (1 - persistance) / (1 - p);
}