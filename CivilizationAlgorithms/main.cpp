#include <stdio.h>
#include <stdlib.h>
#include <SDL.h>
#include "Calcul.h"

// On définit la taille de l'image.
#define TAILLE 512
// On définit le nombre d'octaves.
#define OCTAVES 8
// On définit le pas.
#define PAS 128
// On définit la persistance.
#define PERSISTANCE 0.5


int main(int argc, char *argv[]) {
	SDL_Surface *ecran = NULL, *img = NULL;
	SDL_Rect position;

	// On initialise la SDL.
	SDL_Init(SDL_INIT_VIDEO);
	ecran = SDL_SetVideoMode(TAILLE, TAILLE, 32,  SDL_ANYFORMAT | SDL_HWSURFACE );
	SDL_WM_SetCaption("Test Bruit cohérent", NULL);

	// On crée une surface SDL pour dessiner dedans.
	img = SDL_CreateRGBSurface(SDL_HWSURFACE, TAILLE, TAILLE, 32, 0, 0, 0, 0);

	initBruit2D(TAILLE + 1, TAILLE + 1, PAS, OCTAVES);

	int x,y;
	for(y = 0; y < TAILLE; y++)
		for(x = 0; x < TAILLE; x++)
			definirPixel(img, x, y, obtenirPixel(x, y));
	destroyBruit2D();

	/* ************ Affichage du résultat **************** */

	position.x = position.y = 0;
	SDL_BlitSurface(img, NULL, ecran, &position);

	// On force l'affichage.
	SDL_Flip(ecran);

	// On attend que l'utilisateur quitte.
	SDL_Event event;
	do
	SDL_WaitEvent( &event );
	while ( event.type!= SDL_QUIT);
	SDL_Quit();

	return EXIT_SUCCESS;
}