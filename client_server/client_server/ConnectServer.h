#ifndef CONNECT_SERVER_H
#define CONNECT_SERVER_H

#include "P2P.h"
#include <sstream>
#include <cstdlib>
class ConnectServer :P2P{
public:
	ConnectServer();
	int connectTo();
	void GetDesktopResolution(int& horizontal, int& vertical);
	void LeftClick();
	void RightClick();
	int* getScreenCoordinates();



};
int ConvertStrToLong(const char* str);

#endif