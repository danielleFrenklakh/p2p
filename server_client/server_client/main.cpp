#pragma comment(lib, "Ws2_32.lib")
#include <stdio.h>
#include <iostream>
#include <Windows.h>
#include <winsock.h>
#include <thread> 

#include "ConnectClient.h"
#include "ConnectServer.h"



using namespace std;

int main()
{
	//MessageBox(NULL, L"would you really like to connect?", L"Confirmation", NULL);
	SOCKET *s = new SOCKET();
	ConnectServer *cc = new ConnectServer();
	cc->connectTo();

	//thread first(coordinations);
	

	
	//std::this_thread::sleep_for(std::chrono::seconds(FPS));

	system("PAUSE");
	return 0;
}
