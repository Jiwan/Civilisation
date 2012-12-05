#include "Calcul.h"

enum TerrainType { WATER, MOUTAIN, FIELD, DESERT };

int Calcul::random_point() {
	return rand() % 3;
}
