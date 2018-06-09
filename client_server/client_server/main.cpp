#pragma comment(lib, "Ws2_32.lib")
#include <stdio.h>
#include <iostream>
#include <Windows.h>
#include <winsock.h>
#include <thread> 

#include "ConnectClient.h"
//#include "ConnectServer.h"




using namespace std;

int main(char argc, char** argv)//The system is getting the ip address from the user interface as starter variables in argv
{
	char* ip = argv[1];
	//ip = "192.168.100.63";
	cout << ip;
	
	//MessageBox(NULL, L"would you really like to connect?", L"Confirmation", NULL);
	SOCKET *s = new SOCKET();
	ConnectClient *cc = new ConnectClient(ip);
	cc->connectTo();

	//std::this_thread::sleep_for(std::chrono::seconds(FPS));

	system("PAUSE");
	return 0;
}


