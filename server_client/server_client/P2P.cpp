#include "P2P.h"
P2P::P2P(){
	_ipAddress = "";//initializes the ip address
}

P2P::~P2P() {}
int* P2P::getScreenCoordinates()//this function is later on showing the principle of polymorphism because it sons are using this function
{
	int coordinates[2] = {};//the array that holds the coordinates in the end abd returns from the function
	int horizontal = 0;//the size of the horizontal
	int vertical = 0;//the size of the vertical
	RECT desktop; // this object stores the upper-left corner, width, and height of a rectangle
	const HWND hDesktop = GetDesktopWindow(); //  Get a handle to the desktop window
	//Get the size of screen to the variable desktop
	GetWindowRect(hDesktop, &desktop);
	// The top left corner will have coordinates (0,0)
	// and the bottom right corner will have coordinates (horizontal, vertical)
	horizontal = desktop.right;
	vertical = desktop.bottom;
	coordinates[0] = horizontal;
	coordinates[1] = vertical;
	return coordinates;

}