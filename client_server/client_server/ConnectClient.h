#ifndef CONNECT_CLIENT_H
#define CONNECT_CLIENT_H
#include <string>
#include <iostream>
#include <stdio.h>
#include "P2P.h"
class ConnectClient : P2P
{
public:
	ConnectClient(char*);
	~ConnectClient();
	int connectTo();
	int sendingEventData();
	void GetDesktopResolution(int& horizontal, int& vertical);
	int* getScreenCoordinates();

};

//unsigned char* readBMP(char* filename);
#endif