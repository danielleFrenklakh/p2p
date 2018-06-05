#ifndef P2P_H
#define P2P_H
#pragma comment(lib, "Ws2_32.lib")
#include <iomanip>

#include <stdio.h>
#include <iostream>
#include <Windows.h>
#include <winsock.h>
#include <stdexcept>
#include <vector>
#include <cstring>
#include <memory>
#include <map>
#include <string.h>

#include <string>

#include "gdiplus.h"
using namespace Gdiplus;
using namespace Gdiplus::DllExports;
#define PORT 3344


class P2P{
public:
	P2P();
	~P2P();
	virtual int connectTo() = 0;

protected:
	SOCKET _ListenSocket;
	SOCKET _server;
	char* _ipAddress;
};


#endif