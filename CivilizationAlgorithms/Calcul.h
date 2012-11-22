#ifndef CALCUL_H
#define CALCUL_H

class Calcul
{
private:
public:

	double interpolation_cos(double a, double b, double x);
	double interpolation_lineaire2D(double a, double b, double c, double d, double x, double y);
	double interpolation_cos2D(double a, double b, double c, double d, double x, double y);
	double interpolation_cubique(double y0, double y1, double y2, double y3, double x);
	double fonction_bruit(double x);
	double fonction_bruit2D(double x, double y);
	double bruit_coherent(double x, double persistance, int nombre_octaves);
	double bruit_coherent2D(double x, double y, double persistance, int nombre_octaves);
	void definirPixel(SDL_Surface *surface, int x, int y, Uint32 pixel);
	Uint32 obtenirCouleur(double rouge, double vert, double bleu);
	Uint32 obtenirPixel(int x, int y);




};

#endif