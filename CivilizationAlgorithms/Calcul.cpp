#include "Calcul.h"

double Calcul::interpolation_cos(double a, double b, double x) {
	double k = (1 - cos(x * PI)) / 2;
	return interpolation_lineaire(a, b, k);
}

double Calcul::interpolation_lineaire2D(double a, double b, double c, double d, double x, double y) {
	i1 = interpolation_lineaire(a, b, x);
	i2 = interpolation_lineaire(c, d, x);
	return interpolation_lineaire(i1, i2, y);
}

double Calcul::interpolation_cos2D(double a, double b, double c, double d, double x, double y) {
	double x1 = interpolation_cos(a, b, x);
	double x2 = interpolation_cos(c, d, x);
	return interpolation_cos(x1, x2, y);
}

double Calcul::interpolation_cubique(double y0, double y1, double y2, double y3, double x) {
	double a = y3 - y2 - y0 + y1;
	double b = y0 - y1 - a;
	double c = y2 - y0;
	double d = y1;

	return a *x * x * x + b * x * x + c * x + d;
}

double Calcul::fonction_bruit(double x) {
	int i = (int) (x / pas);
	return interpolation_cos(bruit(i), bruit(i + 1), (x / pas) % 1);
}

double Calcul::fonction_bruit2D(double x, double y) {
	int i = (int) (x / pas);
	int j = (int) (y / pas);
	return interpolation_cos2D(bruit2D(i, j), bruit2D(i + 1, j), bruit2D(i, j + 1), bruit2D(i + 1, j + 1), (x / pas) % 1, (y / pas) % 1);
}

double Calcul::bruit_coherent(double x, double persistance, int nombre_octaves) {

	double somme = 0;
	double p = 1;
	int f = 1;

	for(int i = 0 ; i < nombre_octaves ; i++) {
		somme += p * fonction_bruit(x * f);
		p *= persistance;
		f *= 2;
	}

	return somme * (1 - persistance) / (1 - p);
}

double Calcul::bruit_coherent2D(double x, double y, double persistance, int nombre_octaves) {

	double somme = 0;
	double p = 1;
	int f = 1;

	for(int i = 0 ; i < nombre_octaves ; i++) {
		somme += p * fonction_bruit2D(x * f, y * f);
		p *= persistance;
		f *= 2;
	}

	return somme * (1 - persistance) / (1 - p);
}
