#include "Matrix.h"
#include "Calcul.h"

Matrix::Matrix(int x, int y) {
	taille_x = x;
	taille_y = y;
	map = new int[taille_x][taille_y];
	for(int i = 0; i < taille_x; i++) {
		for(int j = 0; j < taille_y; j++) {
			map[i][j] = Calcul::random_point();
		}
	}
	return map;
}


void Matrix::setValue(int x, int y, int v) {
	map[x][y] = v;
}

void Matrix::smoothNoise_2D(int x, int y) {
	if (x <= taille_x && y <= taille_y) {
		int cote1;
		int cote2;
		int cote3;
		int cote4;
		if (x - 1 >= 0 && y - 1 >= 0 ) {
			cote1 = map[x - 1][y - 1];
		}
		if (x + 1 <= taille_x && y - 1 >= 0 ) {
			cote2 = map[x + 1][y - 1];
		}
		if (x - 1 >= 0 && y + 1 <= taille_y ) {
			cote3 = map[x - 1][y + 1];
		}
		if (x + 1 <= taille_x && y + 1 <= taille_y ) {
			cote4 = map[x + 1][y + 1];
		}
		int moy_cotes = (cote1 + cote2 + cote3 + cote4)/4
	}





}