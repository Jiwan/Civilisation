#include <stdio.h>
#include <stdlib.h>
#include <iostream>

#include "PerlinNoise.h"
#include "BasicSquareRandomizer.h"

int main(int argc, char* argv[])
{
	BasicSquareRandomizer randomizer;
	PerlinNoiseMap<> test(25, 25);
	
	test.generateHeightMap(reinterpret_cast<ISquareRandomizer*>(&randomizer), 100.0f);

	std::cout << test;

	system("PAUSE");
	return EXIT_SUCCESS;
}