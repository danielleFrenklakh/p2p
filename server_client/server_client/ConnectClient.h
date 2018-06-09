#ifndef CONNECT_CLIENT_H
#define CONNECT_CLIENT_H
#include <string> //allows functions on strings
#include "P2P.h" //includes his father's header in order to inherit from him and get his fields, function and includes 
class ConnectClient : P2P
{
public:
	ConnectClient(char*);
//	~ConnectClient();
	int connectTo();//overrides the virtual function of the father
	int sendingEventData();//handelng and sending via socket the events
	//int* getScreenCoordinates();

};
//unsigned char* readBMP(char* filename);
#endif