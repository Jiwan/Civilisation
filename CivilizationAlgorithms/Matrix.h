#ifndef CALCUL_H
#define CALCUL_H

class Matrix
{
private:
	int taille_x;
	int taille_y;
	int[][] map;

public:
	Matrix(int x, int y);
	void setValue(int x, int y, int v);
};

#endif