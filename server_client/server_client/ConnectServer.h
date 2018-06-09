#ifndef CONNECT_SERVER_H
#define CONNECT_SERVER_H

#include "P2P.h" //includes his father's header in order to inherit from him and get his fields, function and includes 
#include <sstream> //Header providing string stream classes
#include <cstdlib> //defines several general purpose functions, including dynamic memory management, random number generation, communication with the environment, integer arithmetics, searching, sorting and converting.

class ConnectServer :P2P{
public:
	ConnectServer();//constructor
	int connectTo();//overrides the virtual function of the father
	void LeftClick();//handles left click events
	void RightClick();//handles right click events
	//int* getScreenCoordinates();////the function gets the computer's resolution



};
#endif