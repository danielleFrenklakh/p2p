#ifndef P2P_H
#define P2P_H
#pragma comment(lib, "Ws2_32.lib")

#include <stdio.h>//C library to perform Input/Output operations
#include <iostream>//provides basic input and output services for C++ programs
#include <Windows.h>//contains declarations for all of the functions in the Windows API
#include <winsock.h>//Windows Sockets API
#include <stdexcept>//defines a set of standard exceptions that  the library and programs can use to report common errors
//#include <vector>
#include <cstring>//defines several functions to manipulate C strings and arrays
#include <memory>//defines general utilities to manage dynamic memory
#include <map>//allows to use a map object and its functions

#include "gdiplus.h"//enables applications to use graphics and formatted text on both the video display and the printer. 
using namespace Gdiplus;
using namespace Gdiplus::DllExports;

#define PORT 3344//defines the port uses to c onnect the two computers


class P2P{
public:
	P2P();//constructor
	~P2P();//diconstructor
	virtual int connectTo() = 0;//defines a virtual function that later will be actualized in the sons
	int* getScreenCoordinates();//gets the coordinates of the computer
protected:
	char* _ipAddress;//the ip of the 'server' side that the program is willing to connect (getting from the user interface
};


#endif